using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaService facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            this.facturaService = facturaService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Factura> lista = await this.facturaService.Listar();
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Factura f = new Factura();
            return View(f);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Factura factura)
        {
            var response = await this.facturaService.Insertar(factura);
            return RedirectToAction("Index");
        }
    }
}