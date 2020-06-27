using GorilaXamDemoApi.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorilaXamDemoApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private GorilaDemoContext _context;
        private BaseRepository<Usuario> _usuario;
        private BaseRepository<Ciudad> _ciudad;
        private BaseRepository<Compra> _compra;
        private BaseRepository<Comuna> _comuna;
        private BaseRepository<Pedido> _pedido;
        private BaseRepository<Producto> _producto;
        private BaseRepository<Tienda> _tienda;

        public UnitOfWork(GorilaDemoContext dbcontext)
        {
            _context = dbcontext;
        }


        public IRepository<Usuario> Usuarios
        {
            get 
            {
                return _usuario ?? (_usuario = new BaseRepository<Usuario>(_context));
            }
        }
        public IRepository<Ciudad> Ciudades
        {
            get
            {
                return _ciudad ?? (_ciudad = new BaseRepository<Ciudad>(_context));
            }
        }
        public IRepository<Compra> Compras
        {
            get
            {
                return _compra ?? (_compra = new BaseRepository<Compra>(_context));
            }
        }
        public IRepository<Comuna> Comunas
        {
            get
            {
                return _comuna ?? (_comuna = new BaseRepository<Comuna>(_context));
            }
        }
        public IRepository<Pedido> Pedidos
        {
            get
            {
                return _pedido ?? (_pedido = new BaseRepository<Pedido>(_context));
            }
        }
        public IRepository<Producto> Productos
        {
            get
            {
                return _producto ?? (_producto = new BaseRepository<Producto>(_context));
            }
        }
        public IRepository<Tienda> Tiendas
        {
            get
            {
                return _tienda ?? (_tienda = new BaseRepository<Tienda>(_context));
            }
        }
        
        //agregar las otras entidades


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
