using System;
using System.Collections.Generic;

namespace BackEnd.ViewModel
{
    public class AuthModel
    {
        public string UserId { get; set; }
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PathImage { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}