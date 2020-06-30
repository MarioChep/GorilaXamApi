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
        private GorilaDemoContext _dbContext;
        private BaseRepository<Usuario> _usuario;
        private BaseRepository<Ciudad> _ciudad;
        private BaseRepository<Compra> _compra;
        private BaseRepository<Comuna> _comuna;
        private BaseRepository<Pedido> _pedido;
        private BaseRepository<Producto> _producto;
        private BaseRepository<Tienda> _tienda;

        public UnitOfWork(GorilaDemoContext dbcontext)
        {
            _dbContext = dbcontext;
        }


        public IRepository<Usuario> Usuarios
        {
            get 
            {
                return _usuario ?? (_usuario = new BaseRepository<Usuario>(_dbContext));
            }
        }
        public IRepository<Ciudad> Ciudades
        {
            get
            {
                return _ciudad ?? (_ciudad = new BaseRepository<Ciudad>(_dbContext));
            }
        }
        public IRepository<Compra> Compras
        {
            get
            {
                return _compra ?? (_compra = new BaseRepository<Compra>(_dbContext));
            }
        }
        public IRepository<Comuna> Comunas
        {
            get
            {
                return _comuna ?? (_comuna = new BaseRepository<Comuna>(_dbContext));
            }
        }
        public IRepository<Pedido> Pedidos
        {
            get
            {
                return _pedido ?? (_pedido = new BaseRepository<Pedido>(_dbContext));
            }
        }
        public IRepository<Producto> Productos
        {
            get
            {
                return _producto ?? (_producto = new BaseRepository<Producto>(_dbContext));
            }
        }
        public IRepository<Tienda> Tiendas
        {
            get
            {
                return _tienda ?? (_tienda = new BaseRepository<Tienda>(_dbContext));
            }
        }
        
        //agregar las otras entidades


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
