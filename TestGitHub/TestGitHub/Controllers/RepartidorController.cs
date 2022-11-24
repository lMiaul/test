using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TestGitHub.Utilidades;

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
            var ObjSesion = HttpContext.Session.Get<Cliente>("scliente");
            if (ObjSesion != null)
            {
                var list = Context.Repartidors;
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
        }
        public IActionResult Registro()
        {
            var ObjSesion = HttpContext.Session.Get<Cliente>("scliente");
            if (ObjSesion != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
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
        [Route("Repartidor/Edit/{codigo}")]
        public IActionResult Edit(int codigo)
        {
            var ObjSesion = HttpContext.Session.Get<Cliente>("scliente");
            if (ObjSesion != null)
            {
                var Obj = (from TRepartidor in Context.Repartidors
                           where TRepartidor.IdRepartidor == codigo
                           select TRepartidor).Single();

                return View(Obj);
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
        }

        public IActionResult EditarRepartidores(Repartidor ObjNew)
        {
            if (ModelState.IsValid)
            {
                var ObjOld = (from TRepartidor in Context.Repartidors
                              where TRepartidor.IdRepartidor == ObjNew.IdRepartidor
                              select TRepartidor).Single();

                ObjOld.IdRepartidor = ObjNew.IdRepartidor;
                ObjOld.NombreRepartidor = ObjNew.NombreRepartidor;
                ObjOld.ApellidoRepartidor = ObjNew.ApellidoRepartidor;

                Context.SaveChanges();
                return RedirectToAction("ListarRepartidores");
            }
            else
            {
                return View("Edit");
            }         
        }
        [Route("Repartidor/Delete/{Codigo}")]
        public IActionResult Delete(int codigo)
        {
            var Obj = (from TRepartidor in Context.Repartidors
                       where TRepartidor.IdRepartidor == codigo
                       select TRepartidor).Single();

            Context.Repartidors.Remove(Obj);
            Context.SaveChanges();
            return RedirectToAction("ListarRepartidores");
        }
    }
}
