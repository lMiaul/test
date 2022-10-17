using Microsoft.AspNetCore.Mvc;

namespace TestGitHub.Controllers
{
    public class ProductoController : Controller
    {
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
            return View();
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
        public IActionResult Boleta()
        {
            return View();
        }
        public IActionResult AddCliente()
        {
            return RedirectToAction("Index");
        }
    }
}
