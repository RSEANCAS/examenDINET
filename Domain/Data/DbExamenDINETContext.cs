using Domain.Data.Configuration;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class DbExamenDINETContext : DbContext
    {
        public DbExamenDINETContext(DbContextOptions<DbExamenDINETContext> options) : base(options) { }

        public DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
