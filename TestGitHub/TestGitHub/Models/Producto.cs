using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGitHub.Models
{
    public partial class Producto
    {
        public uint CodigoProducto { get; set; }
        [Required(ErrorMessage = "El campo Nombre debe ser llenado.")]
        public string NombreProducto { get; set; } = null!;
        [Required(ErrorMessage = "El campo Descripción debe ser llenado.")]
        public string DescripcionProducto { get; set; } = null!;
        [Required(ErrorMessage = "El campo Codigo debe ser llenado.")]
        public int CodigoCategoria { get; set; }
        [Required(ErrorMessage = "El campo Stock debe ser llenado.")]
        [Range(1,int.MaxValue, ErrorMessage = "El stock debe ser mayor a 0.")]
        public int StockProducto { get; set; }
        [Required(ErrorMessage = "El campo Precio debe ser llenado.")]
        public float PrecioProducto { get; set; }
        [Required(ErrorMessage = "El campo URL debe ser llenado.")]
        public string? UrlImagen { get; set; }
        [NotMapped]
        public int CantidadEscogida { get; set; }
    }
}
