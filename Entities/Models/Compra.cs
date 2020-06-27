using System;
using System.Collections.Generic;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class Compra
    {
        public int CompraId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? FechaCompra { get; set; }
        public int? MontoPago { get; set; }
        public string TipoPago { get; set; }
        public string Descripcion { get; set; }
        public int? PedidoId { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
