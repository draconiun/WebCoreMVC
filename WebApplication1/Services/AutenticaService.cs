using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Config;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AutenticaService : IAutenticaService
    {
        private readonly ParametroConfig options;
        private readonly IHttpContextAccessor accessor;

        public AutenticaService(IOptions<ParametroConfig> options, IHttpContextAccessor accessor)
        {
            this.options = options.Value;
            this.accessor = accessor;
        }
        public async Task<DTORecibeAutentica> Validar(Autentica autentica)
        {
            string ruta = options.urlbase + options.metodoautentica;
            DTOEnviaAutentica param = new DTOEnviaAutentica(autentica, options);

            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type", param.grant_type));
            nvc.Add(new KeyValuePair<string, string>("client_id", param.client_id));
            nvc.Add(new KeyValuePair<string, string>("client_secret", param.client_secret));
            nvc.Add(new KeyValuePair<string, string>("scope", param.scope));
            nvc.Add(new KeyValuePair<string, string>("username", param.username));
            nvc.Add(new KeyValuePair<string, string>("password", param.password));
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add(
            //        options.tokenapiname,
            //        options.tokenapivalue);

            var req = new HttpRequestMessage(HttpMethod.Post, ruta) { Content = new FormUrlEncodedContent(nvc) };

            var resp = await client.SendAsync(req);

            var data = await resp.Content.ReadAsStringAsync();
            DTORecibeAutentica respuesta = JsonConvert.DeserializeObject<DTORecibeAutentica>(data);
            return respuesta;
            
        }
    }
}
