using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestGitHub.Models
{
    public partial class bdproductoContext : DbContext
    {
        public bdproductoContext()
        {
        }

        public bdproductoContext(DbContextOptions<bdproductoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("int(6) unsigned zerofill")
                    .HasColumnName("id_Cliente");

                entity.Property(e => e.ApellidosCliente)
                    .HasMaxLength(35)
                    .HasColumnName("apellidos_Cliente");

                entity.Property(e => e.ContraCliente)
                    .HasMaxLength(10)
                    .HasColumnName("contra_Cliente")
                    .IsFixedLength();

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(50)
                    .HasColumnName("email_Cliente");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(35)
                    .HasColumnName("nombre_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
