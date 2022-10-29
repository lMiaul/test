using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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
        [Route("Repartidor/Edit/{codigo}")]
        public IActionResult Edit(int codigo)
        {
            var Obj = (from TRepartidor in Context.Repartidors
                       where TRepartidor.IdRepartidor == codigo
                       select TRepartidor).Single();

            return View(Obj);
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
