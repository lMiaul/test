using Microsoft.AspNetCore.Mvc;

namespace TestGitHub.Controllers
{
    public class RepartidorController : Controller
    {
        private readonly bdproductoContext Context;
        public RepartidorController(bdproductoContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Repartidor/ope/listar")]
        public IActionResult ListarRepartidores()
        {
            var list = Context.Repartidors;
            return View(list);
        }
        public IActionResult Registro()
        {
            return View();
        }
        public IActionResult RegistrarRepartidor(Repartidor obj)
        {
            if (ModelState.IsValid)
            {
                Context.Repartidors.Add(obj);
                Context.SaveChanges();
                return RedirectToAction("ListarRepartidores");
            }
            else
            {
                return RedirectToAction("Registro");
            }
        }
    }
}
