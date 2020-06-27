using System;
using System.Collections.Generic;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class Comuna
    {
        public Comuna()
        {
            Tienda = new HashSet<Tienda>();
            Usuario = new HashSet<Usuario>();
        }

        public int ComunaId { get; set; }
        public int? CiudadId { get; set; }
        public string Nombre { get; set; }

        public virtual Ciudad Ciudad { get; set; }
        public virtual ICollection<Tienda> Tienda { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
