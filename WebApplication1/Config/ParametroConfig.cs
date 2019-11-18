using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Config
{
    public class ParametroConfig
    {
        public string urlbase { get; set; }
        public string metodoautentica { get; set; }
        public string metodosend { get; set; }
        public string metodolistafactura { get; set; }
        public string metodolistahistorico { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string scope { get; set; }
        public string tokenapiname { get; set; }
        public string tokenapivalue { get; set; }
    }
}
