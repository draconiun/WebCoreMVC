using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAutenticaService autenticaService;

        public LoginController(IAutenticaService autenticaService)
        {
            this.autenticaService = autenticaService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Autentica model = new Autentica();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Autentica request) {

            var resp = await autenticaService.Validar(request);
            if(resp.error == null)
            {
                //Grabes en sesion el token
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}