using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CharTex.Models
{
    public class Chartex_Context:DbContext
    {
        public Chartex_Context(DbContextOptions<Chartex_Context> options)
            : base(options)
        {
        }

        public DbSet<Persions> _Persions { get; set; }
        public DbSet<Orders> _Orders { get; set; }
        public DbSet <Chartex_view> _Chartex_Views { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chartex_view>(entity => {
               
                entity.ToTable("view_chrtext1");
               
            });
        }

    }
}
