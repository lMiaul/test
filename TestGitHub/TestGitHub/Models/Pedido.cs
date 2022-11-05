using System;
using System.Collections.Generic;

namespace TestGitHub.Models
{
    public partial class Pedido
    {
        public uint CodigoPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdRepartidor { get; set; }
        public float TotalPedido { get; set; }
        public string EstadoPedido { get; set; } = null!;
    }
}
