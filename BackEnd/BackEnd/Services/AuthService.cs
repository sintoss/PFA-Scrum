using BackEnd.Helpers;
using BackEnd.Models;
using BackEnd.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Utilisateur> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IENCRYPTION crypt;
        private readonly JWT _jwt;

        public AuthService(UserManager<Utilisateur> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt , IENCRYPTION crypt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.crypt = crypt;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
             if (await _userManager.FindByEmailAsync(model.Email) is not null)
                 return new AuthModel { Message = "Email is already registered!" };

             if (await _userManager.FindByNameAsync(model.Username) is not null)
                 return new AuthModel { Message = "Username is already registered!" };

            if (model.file is null)
                return new AuthModel { Message = "Avtar picture has some problem!" };

            Utilisateur user = (Utilisateur)Activator.CreateInstance(Type.GetType("BackEnd.Models."+model.acctype)); ;

             if (user is null)
                 return new AuthModel { Message = "this type of user does not exist!" };

             user.UserName = model.Username;
             user.Email = model.Email;

            // logic of upload images

            var file = model.file;

            if (file.Length > 0)
            {
                var foldername = Path.Combine("Ressources", "Image");
                var pathtosave = Path.Combine(Directory.GetCurrentDirectory(), foldername);

                string[] exts = { ".jpg", ".png", ".jpeg" };
                if (exts.Contains(Path.GetExtension(file.FileName)))
                {

                    DateTime dt = DateTime.Now;
                    string NewName = dt.Year + dt.Month
                        + dt.Day + dt.Hour + dt.Minute
                        + dt.Second + dt.Millisecond + Path.GetFileNameWithoutExtension(file.FileName);

                    NewName = crypt.GetHash(NewName);

                    NewName += Path.GetExtension(file.FileName);

                    var FullPath = Path.Combine(pathtosave, NewName);
                    var dbpath = Path.Combine(foldername, NewName);

                    using (var stream = new FileStream(FullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    user.pathImage = dbpath;

                }
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, model.acctype);

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                UserId = user.Id,
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                PathImage = user.pathImage,
                Roles = new List<string> { model.acctype },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.UserId = user.Id;
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.PathImage = user.pathImage;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Sonething went wrong";
        }

        private async Task<JwtSecurityToken> CreateJwtToken(Utilisateur user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }
}