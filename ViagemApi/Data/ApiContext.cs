﻿using Microsoft.EntityFrameworkCore;
using ViagemApi.Model;

namespace ViagemApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depoimento>().Property(s => s.name).HasMaxLength(100);

            modelBuilder.Entity<Depoimento>().Property(s => s.depoimento).HasMaxLength(300);

            modelBuilder.Entity<Depoimento>().Property(s => s.foto).IsRequired();

            modelBuilder.Entity<Destino>().Property(s => s.Name).HasMaxLength(100);

            modelBuilder.Entity<Destino>().Property(s => s.Foto).HasMaxLength(300);

            modelBuilder.Entity<Destino>().Property(s => s.Price).IsRequired();

        }
        public DbSet<Depoimento> Depoimentos { get; set; }
        public DbSet<Destino> Destinos { get; set; }


    }
}
