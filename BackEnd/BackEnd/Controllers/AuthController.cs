using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using BackEnd.Services;
using BackEnd.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            model.file = Request.Form.Files["file"];

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return Ok(result.Message);


            return Ok(result);

        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return Ok(result.Message);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        [HttpPost("decodeJw")]
        public IActionResult decodeJw(string token)
        {
            var handler =  new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(token);
            return  Ok(decodedValue);
        }
    }
}