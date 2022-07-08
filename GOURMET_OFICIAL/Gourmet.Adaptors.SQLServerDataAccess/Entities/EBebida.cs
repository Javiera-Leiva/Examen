using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class EBebida : IEntityTypeConfiguration<Bebida>
    {
        public void Configure(EntityTypeBuilder<Bebida> builder)
        {
            builder.ToTable("tb_Bebida");

            builder.HasKey(b => b.Id_Bebida);

            builder
                .HasMany(b => b.Menus)
                .WithOne(men => men.Bebida);

            builder
                .HasMany(p => p.Pedido_Ventas)
                .WithOne(men => men.Bebida);

        }
    }
}
