using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestGitHub.Models
{
    public partial class Cliente
    {
        
        public uint IdCliente { get; set; }
        [Required(ErrorMessage = "El campo NOMBRE no esta completo.")]
        public string NombreCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo APELLIDOS no esta completo.")]
        public string ApellidosCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo EDAD no esta completo.")]
        public int EdadCliente { get; set; }
        [Required(ErrorMessage = "El campo TELEFONO no esta completo.")]
        public int TelefonoCliente { get; set; }
        [Required(ErrorMessage = "El campo DIRECCION no esta completo.")]
        public string DireccionCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo EMAIL no esta completo.")]
        public string EmailCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo CONTRASEÑA no esta completo.")]
        public string ContraCliente { get; set; } = null!;
    }
}
