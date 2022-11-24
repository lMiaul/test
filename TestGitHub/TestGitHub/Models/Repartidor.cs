using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace TestGitHub.Models
{
    public partial class Repartidor
    {
        public uint IdRepartidor { get; set; }
        [Required(ErrorMessage = "El campo Nombre debe ser llenado.")]
        public string NombreRepartidor { get; set; } = null!;
        [Required(ErrorMessage = "El campo Apellido debe ser llenado.")]
        public string ApellidoRepartidor { get; set; } = null!;
    }
}
