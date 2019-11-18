using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Config;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly ParametroConfig options;

        public FacturaService(IOptions<ParametroConfig> options)
        {
            this.options = options.Value;
        }
        public async Task<DTORecibeSend> Insertar(Factura factura)
        {
            HttpClient client = new HttpClient();
            string url = options.urlbase + options.metodosend;

            #region Headers

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjZiODVjNGJkODZhYjIyOGVmMWEyYmExODU1NjA5YTM4IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NzQwMzQxODQsImV4cCI6MTU3NDAzNzc4NCwiaXNzIjoiaHR0cDovL2FwaXNlZ3VyaWRhZGdhbGF4eTo4MDgwIiwiYXVkIjpbImh0dHA6Ly9hcGlzZWd1cmlkYWRnYWxheHk6ODA4MC9yZXNvdXJjZXMiLCJhcGlmYWN0dXJhIiwiYXBpaGlzdG9yaWNvIiwiYXBpc2VuZGVyIl0sImNsaWVudF9pZCI6ImFuZ3VsYXIiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNTc0MDM0MTg0LCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbImFwaWZhY3R1cmEiLCJhcGloaXN0b3JpY28iLCJhcGlzZW5kZXIiXSwiYW1yIjpbInB3ZCJdfQ.dvqKKNlE0nitu_9eg-P5GOAKA_rUh5zS16BbYne5eV_y_w6XA9tiSXruYBAa0uSXeMDwx78RBoxUTaPTeyz0saUaoXNXPv_9_YU-3pTC1vD-Dfafu6LXKbM9pa59Pb2SavkWRRVZ6NQ5tDMuoYkbUuAK7kiRshNmp4540WGA_elgLdTniZr9cS83xfDcvH5Eias--9i3fejj9tMhih8BWJRpW_XtfPuh3fCCGBWR2s4OE5VqQ-QwvhU7zOGIQmkYXT91MvqVxlrDYHkeU26AJHurQboqboSTfq7lmA-CfbNbTcr16SEEdEJam61qRBD6nHol5b1tQkw-W5Hg_JTLkA");

            #endregion

            var response = await client.PostAsJsonAsync(url, factura);
            //var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var codigo = response.StatusCode;
            var data = await response.Content.ReadAsStringAsync();
            DTORecibeSend respuesta = JsonConvert.DeserializeObject<DTORecibeSend>(data);

            return respuesta;
        }

        public async Task<List<Factura>> Listar()
        {
            HttpClient client = new HttpClient();
            string url = options.urlbase + options.metodolistafactura;

            #region Headers

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjZiODVjNGJkODZhYjIyOGVmMWEyYmExODU1NjA5YTM4IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NzQwMzQxODQsImV4cCI6MTU3NDAzNzc4NCwiaXNzIjoiaHR0cDovL2FwaXNlZ3VyaWRhZGdhbGF4eTo4MDgwIiwiYXVkIjpbImh0dHA6Ly9hcGlzZWd1cmlkYWRnYWxheHk6ODA4MC9yZXNvdXJjZXMiLCJhcGlmYWN0dXJhIiwiYXBpaGlzdG9yaWNvIiwiYXBpc2VuZGVyIl0sImNsaWVudF9pZCI6ImFuZ3VsYXIiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNTc0MDM0MTg0LCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbImFwaWZhY3R1cmEiLCJhcGloaXN0b3JpY28iLCJhcGlzZW5kZXIiXSwiYW1yIjpbInB3ZCJdfQ.dvqKKNlE0nitu_9eg-P5GOAKA_rUh5zS16BbYne5eV_y_w6XA9tiSXruYBAa0uSXeMDwx78RBoxUTaPTeyz0saUaoXNXPv_9_YU-3pTC1vD-Dfafu6LXKbM9pa59Pb2SavkWRRVZ6NQ5tDMuoYkbUuAK7kiRshNmp4540WGA_elgLdTniZr9cS83xfDcvH5Eias--9i3fejj9tMhih8BWJRpW_XtfPuh3fCCGBWR2s4OE5VqQ-QwvhU7zOGIQmkYXT91MvqVxlrDYHkeU26AJHurQboqboSTfq7lmA-CfbNbTcr16SEEdEJam61qRBD6nHol5b1tQkw-W5Hg_JTLkA");

            #endregion

            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var codigo = response.StatusCode;
            var data = await response.Content.ReadAsStringAsync();
            List<Factura> listaRes = JsonConvert.DeserializeObject<List<Factura>>(data);

            return listaRes;
        }
    }
}
