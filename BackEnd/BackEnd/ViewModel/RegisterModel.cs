using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.ViewModel
{
    public class RegisterModel
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string acctype { get; set; }
        public IFormFile file { get; set; }

    }
}