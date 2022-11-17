using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace TestGitHub.Models
{
    public partial class Repartidor
    {
        public uint IdRepartidor { get; set; }
        [Required(ErrorMessage = "Nombre del Repartidor es obligatorio")]
        public string NombreRepartidor { get; set; } = null!;
        [Required(ErrorMessage = "Apellido del Repartidor es obligatorio")]
        public string ApellidoRepartidor { get; set; } = null!;
    }
}
