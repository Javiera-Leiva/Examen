using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class EUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_Usuario");

            builder.HasKey(u => u.Id_Usuario );

            builder
                .HasMany(u => u.Pedido_Ventas)
                .WithOne(dp => dp.Usuario);

        }
    }
}
