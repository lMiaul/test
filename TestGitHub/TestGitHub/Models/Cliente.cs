using System;
using System.Collections.Generic;

namespace TestGitHub.Models
{
    public partial class Cliente
    {
        public uint IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? ApellidosCliente { get; set; }
        public int? EdadCliente { get; set; }
        public int? TelefonoCliente { get; set; }
        public string? DireccionCliente { get; set; }
        public string EmailCliente { get; set; } = null!;
        public string ContraCliente { get; set; } = null!;
    }
}
