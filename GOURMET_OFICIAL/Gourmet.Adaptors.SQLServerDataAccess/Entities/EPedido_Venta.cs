using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class EPedido_Venta : IEntityTypeConfiguration<Pedido_Venta>
    {
        public void Configure(EntityTypeBuilder<Pedido_Venta> builder)
        {
            builder.ToTable("tb_PedidoVenta");

            builder.HasKey(pv => pv.Id_Pedido);

            builder
                 .HasOne(P => P.Plato)
                 .WithMany(pv => pv.Pedido_Ventas);
            builder
                .HasOne(B => B.Bebida)
                .WithMany(pv => pv.Pedido_Ventas);
            builder
               .HasOne(U => U.Usuario)
               .WithMany(pv => pv.Pedido_Ventas);
        }
    }
}
