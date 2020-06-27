using GorilaXamDemoApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorilaXamDemoApi.Services
{
    public interface IUnitOfWork
    {
        IRepository<Usuario> Usuarios { get; }
        IRepository<Ciudad> Ciudades { get; }
        IRepository<Compra> Compras { get; }
        IRepository<Comuna> Comunas { get; }
        IRepository<Pedido> Pedidos { get; }
        IRepository<Tienda> Tiendas { get; }

        void Save();
    }
}
