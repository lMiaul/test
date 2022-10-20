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
        
   
        public IActionResult AddCliente(Cliente obj)
        {
            if (ModelState.IsValid)
            {
                Context.Clientes.Add(obj);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Registro");
            }
            
        }

        [Route("cliente/Delete/{Codigo}")]
        public IActionResult Delete(string Codigo)
        {
            var Obj = (from Tcliente in Context.Clientes
                       where Tcliente.IdCliente == Codigo
                       select Tcliente).Single();
            Context.Clientes.Remove(Obj);
            Context.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}
