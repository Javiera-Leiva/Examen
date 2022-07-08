using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class ECategoria_Bebida : IEntityTypeConfiguration<Categoria_Bebida>
    {
        public void Configure(EntityTypeBuilder<Categoria_Bebida> builder)
        {
            builder.ToTable("tb_CategoriaBebida");

            builder.HasKey(cb => cb.Id_CategoriaBebida);

            builder
                .HasMany(cb => cb.Bebidas)
                .WithOne(b => b.Categoria_Bebida);

        }
    }
}

