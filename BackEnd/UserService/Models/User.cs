using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models.Enum;

namespace UserService.Models
{
    public class User : Entity
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public String PhoneNumber { get; set; }
        public String Biography { get; set; }
        public String WorkExperience { get; set; }
        public String Education { get; set; }
        public String Skill { get; set; }
        public String Interest { get; set; }
        public bool Enabled { get; set; }
        public Gender Gender { get; set; }
        public bool Privacy { get; set; }
        public DateTime DateOfBirth { get; set; }
      
    }
}
