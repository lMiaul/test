using System;
using System.Collections.Generic;

namespace TestGitHub.Models
{
    public partial class DetallePedido
    {
        public int IdDetalleVenta { get; set; }
        public uint CodigoPedido { get; set; }
        public uint CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioVenta { get; set; }

        public virtual Pedido CodigoPedidoNavigation { get; set; } = null!;
        public virtual Producto CodigoProductoNavigation { get; set; } = null!;
    }
}
