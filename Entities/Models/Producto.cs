using System;
using System.Collections.Generic;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Estilo { get; set; }
        public string Tamaño { get; set; }
        public string Descripcion { get; set; }
        public int? Valoracion { get; set; }
        public int? Precio { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
