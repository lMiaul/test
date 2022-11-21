using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace TestGitHub.Models
{
    public partial class Cliente
    {
        public uint IdCliente { get; set; }
        [Required(ErrorMessage = "El campo Nombre debe ser llenado.")]
        public string? NombreCliente { get; set; }
        [Required(ErrorMessage = "El campo Apellido debe ser llenado.")]
        public string ApellidosCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo Edad debe ser llenado.")]
        public int? EdadCliente { get; set; }
        [Required(ErrorMessage = "El campo Telefono debe ser llenado.")]
        public int? TelefonoCliente { get; set; }
        [Required(ErrorMessage = "El campo Direccion debe ser llenado.")]
        public string? DireccionCliente { get; set; }
        [Required(ErrorMessage = "El campo Email debe ser llenado.")]
        public string EmailCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo Contraseña debe ser llenado.")]
        public string ContraCliente { get; set; } = null!;
    }
}
