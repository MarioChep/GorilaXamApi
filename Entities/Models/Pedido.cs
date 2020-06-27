using System;
using System.Collections.Generic;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Compra = new HashSet<Compra>();
            Tienda = new HashSet<Tienda>();
        }

        public int PedidoId { get; set; }
        public int? TiendaId { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int? ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Tienda> Tienda { get; set; }
    }
}
