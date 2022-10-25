using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace TestGitHub.Controllers
{
    public class ClienteController : Controller
    {
        private readonly bdproductoContext Context;
        public ClienteController(bdproductoContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Cliente/ope/listar")]
        public IActionResult ListarClientes()
        {
            var list = Context.Clientes;
            return View(list);
        }
        public IActionResult Registro()
        {
            return View();
        }
        public IActionResult RegistrarCliente(Cliente obj)
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

        [Route("Cliente/Edit/{Codigo}")]
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
                return View("Edit");
            }
        }
        [Route("cliente/Delete/{Codigo}")]
        public IActionResult Delete(int Codigo)
        {
            var Obj = (from Tcliente in Context.Clientes
                       where Tcliente.IdCliente == Codigo
                       select Tcliente).Single();
            Context.Clientes.Remove(Obj);
            Context.SaveChanges();
            return RedirectToAction("ListarClientes");
        }

        public IActionResult ValidarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var Obj = (from TCliente in Context.Clientes
                           where TCliente.EmailCliente == cliente.EmailCliente
                           && TCliente.ContraCliente == cliente.ContraCliente
                           select TCliente).FirstOrDefault();
                if (Obj == null)
                {
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetString("scliente", JsonConvert.SerializeObject(cliente));
                    return RedirectToAction("Menu", "Producto");
                }
            }
            else
            {
                return View("Index");
            }
        }
    }
}
