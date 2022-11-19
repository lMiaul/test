using Microsoft.AspNetCore.Mvc;


using TestGitHub.Helpers;
using TestGitHub.Providers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TestGitHub.Extensions;
using System.Linq;

namespace TestGitHub.Controllers

{
    public class ProductoController : Controller
    {
        private readonly bdproductoContext Context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductoController(bdproductoContext context, IWebHostEnvironment webHost)
        {
            Context = context;
            webHostEnvironment = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*public static List<Producto> lstProductoTemporal = new List<Producto>();

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
        }*/
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
           /* var list = (from TAbarrotes in Context.Productos
                        where T)*/
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

        [Route("Producto/BuscarProducto")]
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
        [HttpPost]
        public IActionResult AddProducto(Producto Obj, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string UFileName = UploadedFile(image);
                Obj.UrlImagen = UFileName;
                Context.Productos.Add(Obj);
                Context.SaveChanges();
                return RedirectToAction("Buscar");
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
        [Route("Producto/ElegirCantidad/{Codigo}")]
        public IActionResult ElegirCantidad(int codigo){
            ViewBag.Categoria = Context.Categorias;
            var Obj = (from TProducto in Context.Productos
                       where TProducto.CodigoProducto == codigo
                       select TProducto).Single();

            return View(Obj);
        }
        
        /*NO ESTA LEYENDO*/
        public string UploadedFile(IFormFile image)
        {
            string uFileName = null;
            if(image != null)
            {
               /* string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uFileName);
                using (var myFileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(myFileStream);
                }*/

            }
            return uFileName = "hola";
        }

        public IActionResult GetProductos (int? codigoProducto)
        {
            if(codigoProducto != null)
            {
                List<int> carrito;
                if(HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                {
                    carrito = new List<int>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                }
                if (carrito.Contains(codigoProducto.Value) == false)
                {
                    carrito.Add(codigoProducto.Value);
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }
            }
            /*ViewBag.Productos, it can be*/
            var productos = Context.Productos;
            return View(productos);
        }
        /*Cambios
         uint por int
            cast de var productos a ser list<Producto>*/
        public List<Producto> GetProductosCarritos(List<int> idProductos)
        {
            var productos = this.Context.Productos.Where(z => idProductos.Contains((int)z.CodigoProducto));
            return (List<Producto>)productos;
        }
        public IActionResult Carrito (int? codigoProducto)
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            if(carrito == null)
            {
                return View();
            }
            else
            {
                if (codigoProducto != null)
                {
                    carrito.Remove(codigoProducto.Value);
                    HttpContext.Session.SetObject("Carrito", carrito);
                }
                //List<Producto> productos = this.context.Productos.Where(z => idproductos.Contains(z.IdProducto));

                List<Producto> productos = this.GetProductosCarritos(carrito);
                return View(productos);
            }
        }
        public IActionResult Pedidos()
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            List<Producto> productos = this.GetProductosCarritos(carrito);
            /*Debo guardar el pedido antes*/
            HttpContext.Session.Remove("CARRITO");
            return View(productos);
        }
    }
}
