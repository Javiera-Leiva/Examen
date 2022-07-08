using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Gourmet.Core.Domain.Models;

using Gourmet.Adaptors.SQLServerDataAccess.Entities;

using Gourmet.Adaptors.SQLServerDataAccess.Utils;


namespace Gourmet.Adaptors.SQLServerDataAccess.Contexts
{

    public class PlantillaDB : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradors { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Categoria_Bebida> Categoria_Bebidas { get; set; }
        public DbSet<Categoria_Plato> Categoria_Platos { get; set; }
        public DbSet<Bebida> Bebidas{ get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Detalle_Pedido> Detalle_Pedidos { get; set; }
        public DbSet<Pedido_Venta> Pedido_Ventas{ get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EUsuario());
            builder.ApplyConfiguration(new EAdministrador());
            builder.ApplyConfiguration(new EMenu());
            builder.ApplyConfiguration(new ECategoria_Bebida());
            builder.ApplyConfiguration(new ECategoria_Plato());
            builder.ApplyConfiguration(new EBebida());
            builder.ApplyConfiguration(new EPlato());
            builder.ApplyConfiguration(new EDetalle_Pedido());
            builder.ApplyConfiguration(new EPedido_Venta());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSetting.SqlServerConnectionString);
        }
    }
}
