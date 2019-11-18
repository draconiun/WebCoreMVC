using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Config;

namespace WebApplication1.Models
{
    public class DTOEnviaAutentica
    {
        public DTOEnviaAutentica()
        {

        }

        public DTOEnviaAutentica(Autentica autentica, ParametroConfig config)
        {
            grant_type = config.grant_type;
            this.password = autentica.password;
            this.scope = config.scope;
            this.username = autentica.username;
            this.client_id = config.client_id;
            this.client_secret = config.client_secret;
        }

        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string scope { get; set; }
        public string username { get; set; }
        public string password { get; set; }

       
    }
}
