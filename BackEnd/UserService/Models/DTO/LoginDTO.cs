using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models.DTO
{
    public class LoginDTO
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string ClientSecret { get; set; }
        public string ClientID { get; set; }
    }
}
