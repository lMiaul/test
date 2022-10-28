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
        
    }
}
