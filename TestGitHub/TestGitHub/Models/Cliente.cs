using System;
using System.Collections.Generic;

#nullable disable
namespace TestGitHub.Models
{
    public partial class Cliente
    {
        
        public uint IdCliente { get; set; }
        
        public string NombreCliente { get; set; } = null!;
        
        public string ApellidosCliente { get; set; } = null!;
        
        public int EdadCliente { get; set; }
        
        public int TelefonoCliente { get; set; }
        
        public string DireccionCliente { get; set; } = null!;
        
        public string EmailCliente { get; set; } = null!;
        
        public string ContraCliente { get; set; } = null!;
    }
}
