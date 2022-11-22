using System;
using System.Collections.Generic;

namespace TestGitHub.Models
{
    public partial class DetallePedido
    {
        public uint CodigoDetallePedido { get; set; }
        public uint CodigoPedido { get; set; }
        public uint CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioVenta { get; set; }
    }
}
