using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    public class LavanderiaContext : DbContext
    {

        public LavanderiaContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; } 
        public virtual DbSet<OrdenesDetails> OrdenesDetails { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; } 
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}
