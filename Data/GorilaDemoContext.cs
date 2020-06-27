using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GorilaXamDemoApi.Entities.Models
{
    public partial class GorilaDemoContext : DbContext
    {
        public GorilaDemoContext()
        {
        }

        public GorilaDemoContext(DbContextOptions<GorilaDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Tienda> Tienda { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                //See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=servergorila.database.windows.net,1433;Initial Catalog=GorilaXamBurger;Persist Security Info=False;User ID=AdmGorilla;Password=Karina21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.Property(e => e.CiudadId)
                    .HasColumnName("CiudadID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.CompraId)
                    .HasColumnName("CompraID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCompra).HasColumnType("date");

                entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

                entity.Property(e => e.TipoPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.PedidoId)
                    .HasConstraintName("FK_Compra_Pedido");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Compra_Usuario");
            });

            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.Property(e => e.ComunaId)
                    .HasColumnName("ComunaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CiudadId).HasColumnName("CiudadID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.Comuna)
                    .HasForeignKey(d => d.CiudadId)
                    .HasConstraintName("FK_Comuna_Ciudad");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PedidoId)
                    .HasColumnName("PedidoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaEntrega).HasColumnType("date");

                entity.Property(e => e.FechaPedido).HasColumnType("date");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.TiendaId).HasColumnName("TiendaID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_Pedido_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId)
                    .HasColumnName("ProductoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Estilo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Tamaño)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.Property(e => e.TiendaId)
                    .HasColumnName("TiendaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComunaId).HasColumnName("ComunaID");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

                entity.HasOne(d => d.Comuna)
                    .WithMany(p => p.Tienda)
                    .HasForeignKey(d => d.ComunaId)
                    .HasConstraintName("FK_Tienda_Comuna");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.Tienda)
                    .HasForeignKey(d => d.PedidoId)
                    .HasConstraintName("FK_Tienda_Pedido");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId)
                    .HasColumnName("UsuarioID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ComunaId).HasColumnName("ComunaID");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rut)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Comuna)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.ComunaId)
                    .HasConstraintName("FK_Usuario_Comuna");
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
