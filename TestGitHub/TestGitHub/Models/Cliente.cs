using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

#nullable disable
namespace TestGitHub.Models
{
    public partial class Cliente
    {
        public uint IdCliente { get; set; }
        [Required(ErrorMessage = "Nombre del Cliente es obligatorio")]
        public string NombreCliente { get; set; } = null!;
        [Required(ErrorMessage = "Apellidos del Cliente es obligatorio")]
        public string ApellidosCliente { get; set; } = null!;
        [Required(ErrorMessage = "Edad del Cliente es obligatorio")]
        public int EdadCliente { get; set; }
        [Required(ErrorMessage = "Teléfono del Cliente es obligatorio")]
        public int TelefonoCliente { get; set; }
        [Required(ErrorMessage = "Direccion del Cliente es obligatorio")]
        public string DireccionCliente { get; set; } = null!;
        [Required(ErrorMessage = "Email del Cliente es obligatorio")]
        public string EmailCliente { get; set; } = null!;
        [Required(ErrorMessage = "Contraseña del Cliente es obligatorio")]
        public string ContraCliente { get; set; } = null!;
    }
}
