using System;
using System.Collections.Generic;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class Tienda
    {
        public int TiendaId { get; set; }
        public int? ComunaId { get; set; }
        public DateTime? Fecha { get; set; }
        public int? PedidoId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual Comuna Comuna { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
