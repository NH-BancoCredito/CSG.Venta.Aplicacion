using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Models;

namespace Venta.Infraestructura.Repositories.Base
{
    public class VentaDbContext : DbContext
    {
        public VentaDbContext(DbContextOptions<VentaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Dominio.Models.Venta> Ventas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuraando las entidades en archivos de tipos separados
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VentaDbContext).Assembly);
            #endregion

            //modelBuilder.Entity<Categoria>(
            //        p =>
            //        {
            //            p.ToTable("Categoria");
            //            p.HasKey(c => c.IdCategoria);
            //        }
            //    );

            //modelBuilder.Entity<Cliente>(
            //     p =>
            //     {
            //         p.ToTable("Cliente");
            //         p.HasKey(c => c.IdCliente);
            //     }
            //);

            //modelBuilder.Entity<Producto>
            //    (
            //        P =>
            //        {
            //            P.ToTable("Producto");
            //            P.HasKey(c => c.IdProducto);
            //            P.Property(c => c.PrecioUnitario).HasPrecision(2);

            //            P.HasOne(p => p.Categoria).WithMany(p => p.Productos).HasForeignKey(p => p.IdCategoria);
            //        }
            //    );

            //modelBuilder.Entity<Dominio.Models.Venta>
            //(
            //    P =>
            //    {
            //        P.ToTable("Venta");
            //        P.HasKey(c => c.IdVenta);


            //        P.HasOne(p => p.Cliente).WithMany(p => p.Ventas).HasForeignKey(p => p.IdCliente);
            //    }
            //);

            //modelBuilder.Entity<Dominio.Models.VentaDetalle>
            //(
            //    P =>
            //    {
            //        P.ToTable("VentaDetalle");
            //        P.HasKey(c => c.IdVentaDetalle);


            //        P.HasOne(p => p.Venta).WithMany(p => p.Detalle).HasForeignKey(p => p.IdVenta);
            //        P.HasOne(p => p.Producto).WithMany(p => p.VentaDetalles).HasForeignKey(p => p.IdProducto);
            //    }
            //);
        }
    }
}
