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
        [HttpGet]
        [Route("cliente/ope/listar")]
        public IActionResult ListarClientes()
        {
            var list = Context.Clientes;
            return View(list);
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
        [Route("Producto/Edit/{Codigo}")]
        public IActionResult Edit(int codigo)
        {

            var Obj = (from Tcliente in Context.Clientes
                       where Tcliente.IdCliente == codigo
                       select Tcliente).Single();

            return View(Obj);
        }
        public IActionResult EditarClientes(Cliente ObjNew)
        {
            if (ModelState.IsValid)
            {
                var ObjOld = (from Tcliente in Context.Clientes
                              where Tcliente.IdCliente == ObjNew.IdCliente
                              select Tcliente).Single();

                ObjOld.IdCliente = ObjNew.IdCliente;
                ObjOld.NombreCliente = ObjNew.NombreCliente;
                ObjOld.ApellidosCliente = ObjNew.ApellidosCliente;
                ObjOld.EdadCliente = ObjNew.EdadCliente;
                ObjOld.TelefonoCliente = ObjNew.TelefonoCliente;
                ObjOld.DireccionCliente = ObjNew.DireccionCliente;
                ObjOld.EmailCliente = ObjNew.EmailCliente;

                Context.SaveChanges();
                return RedirectToAction("ListarClientes");
            }
            else
            {
                return View("EditarClientes");
            }
        }
        
    }
}
