﻿using System;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=bdproducto;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

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