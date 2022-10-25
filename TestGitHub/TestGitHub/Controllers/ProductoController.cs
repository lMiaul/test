using Microsoft.AspNetCore.Mvc;

namespace TestGitHub.Controllers
{
    public class ProductoController : Controller
    {
        private readonly bdproductoContext Context;
        public ProductoController(bdproductoContext context)
        {
            Context = context;  
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }
        public IActionResult Menu()
        {
            var ObjSesion = HttpContext.Session.GetString("scliente");
            if (ObjSesion != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Cliente");
            }
        }

        public IActionResult Abarrotes()
        {
            return View();
        }
        public IActionResult Mascotas()
        {
            return View();
        }
        public IActionResult Bebidas()
        {
            return View();
        }
        public IActionResult Medicamentos()
        {
            return View();
        }
        public IActionResult Higiene()
        {
            return View();
        }
        public IActionResult CarritoDeCompra()
        {
            return View();
        }
        public IActionResult Validar()
        {
            return View();
        }
        public IActionResult Boleta()
        {
            return View();
        }
        
   


        
    }
}
