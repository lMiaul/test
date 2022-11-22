using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGitHub.Models
{
    public partial class Producto
    {
        public uint CodigoProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string DescripcionProducto { get; set; } = null!;
        public int CodigoCategoria { get; set; }
        public int StockProducto { get; set; }
        public float PrecioProducto { get; set; }
        public string? UrlImagen { get; set; }
        [NotMapped]
        public int CantidadEscogida { get; set; }
    }
}
