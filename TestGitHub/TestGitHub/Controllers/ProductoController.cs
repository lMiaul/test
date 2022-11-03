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
        
        public IActionResult Menu()
        {
            var ObjSesion = HttpContext.Session.GetString("scliente");
            if (ObjSesion != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
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

        /*[Route("Cliente/BuscarProducto")]
        public IActionResult Buscar()
        {
            var list = Context.Productos;
            return View(list);
        }*/
        
        public IActionResult Registro()
        {
            ViewBag.Categoria = Context.Categorias;
            return View();
        }
        public IActionResult AddProducto(Producto Obj)
        {
            if (ModelState.IsValid)
            {
                Context.Productos.Add(Obj);
                Context.SaveChanges();
                return View("ListarProductos");
            }
            else
            {
                ViewBag.Categoria = Context.Categorias;
                return RedirectToAction("Registro", "Producto");
            }
            
        }

        
    }
}
