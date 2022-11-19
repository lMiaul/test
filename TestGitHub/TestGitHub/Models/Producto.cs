using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace TestGitHub.Models
{
    public partial class Producto
    {
        public uint CodigoProducto { get; set; }
        [Required(ErrorMessage = "Nombre del Producto es obligatorio")]
        public string NombreProducto { get; set; } = null!;
        [Required(ErrorMessage = "Descripcion del Producto es obligatorio")]
        public string DescripcionProducto { get; set; } = null!;
        [Required(ErrorMessage = "Tipo de la Categoria es obligatorio")]
        public int CodigoCategoria { get; set; }
        [Required(ErrorMessage = "Stock del Producto es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock debe ser Mayor a cero.")]
        public int StockProducto { get; set; }
        [Required(ErrorMessage = "Precio del Producto es obligatorio")]
        [Range(1, float.MaxValue, ErrorMessage = "El precio debe ser Mayor a cero.")]
        public float PrecioProducto { get; set; }
        public string? UrlImagen { get; set; }

        [NotMapped]
        public IFormFile ImagenFile { get; set; }
    }
}
