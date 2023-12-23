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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(
                    p =>
                    {
                        p.ToTable("Categoria");
                        p.HasKey(c => c.IdCategoria);
                    }
                );
            modelBuilder.Entity<Producto>
                (
                    P =>
                    {
                        P.ToTable("Producto");
                        P.HasKey(c => c.IdProducto);
                        P.Property(c => c.PrecioUnitario).HasPrecision(2);

                        P.HasOne(p => p.Categoria).WithMany(p => p.Productos).HasForeignKey(p => p.IdCategoria);
                    }
                );
        }
    }
}
