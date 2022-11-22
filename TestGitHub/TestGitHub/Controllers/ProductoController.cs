using Microsoft.AspNetCore.Mvc;

using TestGitHub.Helpers;
using TestGitHub.Providers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TestGitHub.Extensions;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Http;
using TestGitHub.Utilidades;
using System.Formats.Asn1;

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

        public IActionResult Abarrotes()
        {
            var list = Context.Productos;
            return View(list);
        }
        public IActionResult Mascotas()
        {
            var list = Context.Productos;
            return View(list);
        }
        public IActionResult Bebidas()
        {
            var list = Context.Productos;
            return View(list);
        }
        public IActionResult Medicamentos()
        {
            var list = Context.Productos;
            return View(list);
        }
        public IActionResult Higiene()
        {
            var list = Context.Productos;
            return View(list);
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
        public IActionResult ElegirCantidad(int codigo)
        {
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
            if (image != null)
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

        public IActionResult GetProductos(uint? codigoProducto)
        {
            if (codigoProducto != null)
            {
                List<uint> carrito;
                if (HttpContext.Session.GetObject<List<uint>>("CARRITO") == null)
                {
                    carrito = new List<uint>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<uint>>("CARRITO");
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
        public IEnumerable<Producto> GetProductosCarritos(List<uint> idProductos)
        {
            IEnumerable<Producto> productos = this.Context.Productos.Where(z => idProductos.Contains(z.CodigoProducto));
            return productos;
        }

        public IActionResult Carrito(uint? codigoProducto)
        {
            List<uint> carrito = HttpContext.Session.GetObject<List<uint>>("CARRITO");
            if (carrito == null)
            {
                return View();
            }
            else
            {

                if (codigoProducto != null)
                {
                    carrito.Remove(codigoProducto.Value);
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }
                //List<Producto> productos = this.context.Productos.Where(z => idproductos.Contains(z.IdProducto));

                IEnumerable<Producto> productos = this.GetProductosCarritos(carrito);
                return View(productos);
            }
        }

        public IActionResult Pedidos()
        {
            List<uint> carrito = HttpContext.Session.GetObject<List<uint>>("CARRITO");
            IEnumerable<Producto> productos = this.GetProductosCarritos(carrito);
            /*Debo guardar el pedido antes*/
            HttpContext.Session.Remove("CARRITO");
            return View(productos);
        }
        /*metodo de accion que reciba un objeto del detalle pedido y guarde la wea */

        public IActionResult GetListaProductos(Producto producto)
        {
            if (producto.CodigoProducto != null)
            {
                List<Producto> carrito;
                if (HttpContext.Session.GetObject<List<Producto>>(WC.SessionCarroCompras) == null)
                {
                    carrito = new List<Producto>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<Producto>>(WC.SessionCarroCompras);
                }
                if (carrito.Contains(producto) == false)
                {
                    carrito.Add(producto);
                    HttpContext.Session.SetObject(WC.SessionCarroCompras, carrito);
                }
            }
            /*ViewBag.Productos, it can be*/
            var productos = HttpContext.Session.GetObject<List<Producto>>(WC.SessionCarroCompras);
            return View(productos);
        }

        public IEnumerable<Producto> GetProductosCarritos(List<Producto> Productos)
        {
            IEnumerable<Producto> productos = this.Context.Productos.Where(z => Productos.Contains(z));
            return productos;
        }

        public IActionResult EliminarProducto(uint codProducto)
        {
            List<Producto> carrito = HttpContext.Session.GetObject<List<Producto>>(WC.SessionCarroCompras);
            if (carrito == null)
            {
                return View();
            }
            else
            {

                foreach (var item in carrito)
                {
                    if (item.CodigoProducto == codProducto)
                    {
                        carrito.Remove(item);
                        HttpContext.Session.SetObject(WC.SessionCarroCompras, carrito);
                        break;
                    }
                }
                /*if (codProducto != null)
                {
                    Producto prod = (from TProducto in Context.Productos
                                     where TProducto.CodigoProducto == codProducto
                                     select TProducto).FirstOrDefault();
                    carrito.Remove(prod);
                    HttpContext.Session.SetObject(WC.SessionCarroCompras, carrito);
                }*/
                //List<Producto> productos = this.context.Productos.Where(z => idproductos.Contains(z.IdProducto));

                IEnumerable<Producto> productos = this.GetProductosCarritos(carrito);
                return View("GetListaProductos", productos);
            }
        }
        public void cambiarPrecioTotal(Pedido pedido, float precioTotal)
        {
            var PedidoOld = (from TPedido in Context.Pedidos
                       where TPedido.CodigoPedido == pedido.CodigoPedido
                       select TPedido).SingleOrDefault();

            PedidoOld.CodigoPedido = pedido.CodigoPedido;
            PedidoOld.IdRepartidor = pedido.IdRepartidor;
            PedidoOld.IdCliente = pedido.IdCliente;
            PedidoOld.TotalPedido = precioTotal;
            PedidoOld.EstadoPedido = pedido.EstadoPedido;

            Context.SaveChanges();
        }

        public IActionResult HacerPedido()
        {
            float precioTotal = 0;
            List<Producto> carrito = HttpContext.Session.GetObject<List<Producto>>(WC.SessionCarroCompras);
            if (carrito == null)
            {
                return View("Menu");
            }
            else
            {
                Cliente clienteSession = HttpContext.Session.Get<Cliente>("scliente");
                Pedido pedido = new Pedido()
                {
                    IdCliente = clienteSession.IdCliente,
                    IdRepartidor = 1,
                    TotalPedido = 0,
                    EstadoPedido = "Pedido"
                };
                Context.Pedidos.Add(pedido);
                Context.SaveChanges();
                
                foreach (var prod in carrito)
                {
                    precioTotal += (float)(prod.CantidadEscogida * prod.PrecioProducto);
                    DetallePedido detallePedido = new DetallePedido()
                    {
                        CodigoPedido = pedido.CodigoPedido,
                        CodigoProducto = prod.CodigoProducto,
                        Cantidad = prod.CantidadEscogida,
                        PrecioVenta = prod.PrecioProducto  
                    };
                    Context.DetallePedidos.Add(detallePedido);
                }
                Context.SaveChanges();

                this.cambiarPrecioTotal(pedido, precioTotal);

                HttpContext.Session.Remove(WC.SessionCarroCompras);

                return View("Menu");
            }
        }
    }
}      
    
    

