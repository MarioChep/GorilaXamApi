using System;
using System.Collections.Generic;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Compra = new HashSet<Compra>();
        }

        public int UsuarioId { get; set; }
        public int? ComunaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }

        public virtual Comuna Comuna { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
    }
}
