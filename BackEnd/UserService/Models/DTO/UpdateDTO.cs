using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models.DTO
{
    public class UpdateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        public string WorkExperience { get; set; }
        public string Education { get; set; }
        public string Skill { get; set; }
        public string Interest { get; set; }
    }
}
