using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class EDetalle_Pedido : IEntityTypeConfiguration<Detalle_Pedido>
    {
        public void Configure(EntityTypeBuilder<Detalle_Pedido> builder)
        {
            builder.ToTable("tb_DetallePedido");

            builder.HasKey(dp => new { dp.Id_Detalle_Pedido});

            builder
                .HasOne(dp => dp.Pedido_Venta)
                .WithMany(pv => pv.Detalle_Pedidos);

     



        }
    }
}
