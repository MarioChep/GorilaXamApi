using System;
using System.Collections.Generic;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Comuna = new HashSet<Comuna>();
        }

        public int CiudadId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Comuna> Comuna { get; set; }
    }
}
