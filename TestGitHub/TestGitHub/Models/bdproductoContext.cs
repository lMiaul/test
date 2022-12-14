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

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Repartidor> Repartidors { get; set; } = null!;

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

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CodigoCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categoria");

                entity.Property(e => e.CodigoCategoria)
                    .HasColumnType("int(10) unsigned zerofill")
                    .HasColumnName("codigo_Categoria");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(25)
                    .HasColumnName("nombre_Categoria");
            });

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

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(100)
                    .HasColumnName("direccion_Cliente");

                entity.Property(e => e.EdadCliente)
                    .HasColumnType("int(3)")
                    .HasColumnName("edad_Cliente");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(50)
                    .HasColumnName("email_Cliente");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(35)
                    .HasColumnName("nombre_Cliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasColumnType("int(9)")
                    .HasColumnName("telefono_Cliente");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.CodigoDetallePedido)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_pedido");

                entity.HasIndex(e => e.CodigoPedido, "FK__PEDIDO__Cod_product__5CD6CB2B");

                entity.HasIndex(e => e.CodigoProducto, "FK__PRODUCTO__Cod_product__5CD6CB2B");

                entity.Property(e => e.CodigoDetallePedido)
                    .HasColumnType("int(20) unsigned zerofill")
                    .HasColumnName("codigo_DetallePedido");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(20)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.CodigoPedido)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("codigo_Pedido");

                entity.Property(e => e.CodigoProducto)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("codigo_Producto");

                entity.Property(e => e.PrecioVenta).HasColumnName("precio_Venta");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.CodigoPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedido");

                entity.HasIndex(e => e.IdCliente, "FK__CLIENTE__Id_client__5CD6CB2B");

                entity.HasIndex(e => e.IdRepartidor, "FK__REPARTIDOR__Id_repart__5CD6CB2B");

                entity.Property(e => e.CodigoPedido)
                    .HasColumnType("int(20) unsigned zerofill")
                    .HasColumnName("codigo_Pedido");

                entity.Property(e => e.EstadoPedido)
                    .HasMaxLength(10)
                    .HasColumnName("estado_Pedido");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("id_Cliente");

                entity.Property(e => e.IdRepartidor)
                    .HasColumnType("int(20) unsigned")
                    .HasColumnName("id_Repartidor");

                entity.Property(e => e.TotalPedido).HasColumnName("total_Pedido");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.CodigoCategoria, "FK__PRODUCTO__Id_cat__5CD6CB2B");

                entity.Property(e => e.CodigoProducto)
                    .HasColumnType("int(10) unsigned zerofill")
                    .HasColumnName("codigo_Producto");

                entity.Property(e => e.CodigoCategoria)
                    .HasColumnType("int(10)")
                    .HasColumnName("codigo_Categoria");

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(20)
                    .HasColumnName("descripcion_Producto");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(20)
                    .HasColumnName("nombre_Producto");

                entity.Property(e => e.PrecioProducto).HasColumnName("precio_Producto");

                entity.Property(e => e.StockProducto)
                    .HasColumnType("int(10)")
                    .HasColumnName("stock_Producto");

                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(500)
                    .HasColumnName("url_Imagen");
            });

            modelBuilder.Entity<Repartidor>(entity =>
            {
                entity.HasKey(e => e.IdRepartidor)
                    .HasName("PRIMARY");

                entity.ToTable("repartidor");

                entity.Property(e => e.IdRepartidor)
                    .HasColumnType("int(10) unsigned zerofill")
                    .HasColumnName("id_Repartidor");

                entity.Property(e => e.ApellidoRepartidor)
                    .HasMaxLength(20)
                    .HasColumnName("apellido_Repartidor");

                entity.Property(e => e.NombreRepartidor)
                    .HasMaxLength(20)
                    .HasColumnName("nombre_Repartidor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
