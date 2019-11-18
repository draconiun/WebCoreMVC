using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IFacturaService
    {
        Task<List<Factura>> Listar();
        Task<DTORecibeSend> Insertar(Factura factura);
    }
}
