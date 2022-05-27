using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models.Enum;

namespace UserService.Util
{
    public class ParseHelper
    {
        public static Gender genderString(string gender)
        {
            if (gender == "0")
            {
                return Gender.Male;
            }

            else
            {
                return Gender.Female;
            }
        }

        public static Gender genderInt(int gender)
        {
            if (gender == 0)
            {
                return Gender.Male;
            }

            else
            {
                return Gender.Female;
            }
        }
    }
}
