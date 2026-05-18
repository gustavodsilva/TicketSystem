using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TicketSystem.Models;
using TicketSystem.Enums;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Banco
{
    internal class TicketSystemContext : DbContext
    {
        public DbSet<Chamado> Chamados_v1 { get; set; }
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketSystem;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.ToTable("Chamados_v1");
                entity.HasKey(e => e.IdUnico);
                entity.Property(e => e.IdUnico).HasColumnName("IdUnico");
                entity.Property(e => e.Titulo).HasColumnName("Titulo").HasMaxLength(255).IsRequired();
                entity.Property(e => e.Descricao).HasColumnName("Descricao");
                entity.Property(e => e.DataCriacao).HasColumnName("DataCriacao");
                entity.Property(e => e.Status).HasColumnName("Status");
            });
        }

    }
}

