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
        public static List<Producto> lstProductoTemporal = new List<Producto>();

        [Route("Producto/{Codigo}")]
        public IActionResult AñadirCarrito(int codigo)
        {
            var Obj = (from TProducto in Context.Productos
                       where TProducto.CodigoProducto == codigo
                       && TProducto.StockProducto != 0
                       select TProducto).Single();
            if(Obj == null)
            {
                return View("Menu");
            }
            else
            {
                
                lstProductoTemporal.Add(Obj);
                ViewBag.lista = lstProductoTemporal;
                return View("Buscar");
            }
        }
        public IActionResult Menu()
        {
            ViewBag.lista = lstProductoTemporal;
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

        [Route("Cliente/BuscarProducto")]
        public IActionResult Buscar()
        {
            var list = Context.Productos;
            return View(list);
        }
        
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
                return View("Buscar");
            }
            else
            {
                ViewBag.Categoria = Context.Categorias;
                return RedirectToAction("Registro", "Producto");
            }
            
        }

        [Route("Producto/Delete/{Codigo}")]
        public IActionResult Delete(int Codigo)
        {
            var Obj = (from Tapo in Context.Productos
                       where Tapo.CodigoProducto == Codigo
                       select Tapo).Single();
            Context.Productos.Remove(Obj);
            Context.SaveChanges();

            return RedirectToAction("Buscar");
        }

        [Route("Producto/Edit/{Codigo}")]
        public IActionResult Edit(int Codigo)
        {
            ViewBag.Categoria = Context.Categorias;

            var Obj = (from Tapo in Context.Productos
                       where Tapo.CodigoProducto == Codigo
                       select Tapo).Single();
            return View(Obj);
        }
        public IActionResult EditarProducto(Producto ObjNew)
        {
            if (ModelState.IsValid)
            {
                var ObjOld = (from Tapo in Context.Productos
                              where Tapo.CodigoProducto == ObjNew.CodigoProducto
                              select Tapo).Single();

                ObjOld.CodigoProducto = ObjNew.CodigoProducto;
                ObjOld.NombreProducto = ObjNew.NombreProducto;
                ObjOld.DescripcionProducto = ObjNew.DescripcionProducto;
                ObjOld.CodigoCategoria = ObjNew.CodigoCategoria;
                ObjOld.StockProducto = ObjNew.StockProducto;
                ObjOld.PrecioProducto = ObjNew.PrecioProducto;

                Context.SaveChanges();
                return RedirectToAction("Buscar");
            }
            else
            {
                ViewBag.Categoria = Context.Categorias;
                return View("Edit");
            }
        }
    }
}
