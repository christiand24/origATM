using System;
using Microsoft.EntityFrameworkCore;
using TestOrigin.Domain.Entities;

namespace TestOrigin.DAL
{
    public class ATMContext: DbContext
    {
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Retiro> Retiros { get; set; }
        public DbSet<Balance> Balances { get; set; }

        public ATMContext() : base()
        {
        }

        public ATMContext(DbContextOptions<ATMContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarjeta>()
                .HasIndex(u => u.Numero)
                .IsUnique();
        }
    }
}
