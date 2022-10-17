using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestGitHub.Models
{
    public partial class Cliente
    {
        public uint IdCliente { get; set; }
        [Required(ErrorMessage = "El campo NOMBRE es Obligatorio")]
        public string NombreCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo APELLIDOS es Obligatorio")]
        public string ApellidosCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo EMAIL es obligatorio")]
        public string EmailCliente { get; set; } = null!;
        [Required(ErrorMessage = "El campo CONTRASEÑA es obligatorio")]
        public string ContraCliente { get; set; } = null!;
    }
}
