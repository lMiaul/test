using Microsoft.AspNetCore.Mvc;

namespace TestGitHub.Controllers
{
    public class ClienteController : Controller
    {
        private readonly bdproductoContext Context;
        public ClienteController(bdproductoContext context)
        {
            Context = context;
        }
        [HttpGet]
        [Route("cliente/ope/listar")]
        public IActionResult ListarClientes()
        {
            var list = Context.Clientes;
            return View(list);
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

    }
}
