using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Configuration
{
    public class ProjectConfiguration : IProjectConfiguration
    {
        public JWT Jwt { get; set; } = new JWT();
        public string ClientSecret { get; set; }
        public DatabaseConfiguration DatabaseConfiguration { get; set; } = new DatabaseConfiguration();
        public string ClientID { get; set; }
    }

    public class JWT
    {
        public string Audience { get; set; }
        public string Key { get; set; }

        public string Subject { get; set; }
        public string Issuer { get; set; }


    }
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }

}
