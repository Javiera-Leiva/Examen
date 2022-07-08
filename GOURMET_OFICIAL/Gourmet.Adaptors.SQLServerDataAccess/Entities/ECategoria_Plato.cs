using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class ECategoria_Plato : IEntityTypeConfiguration<Categoria_Plato>
    {
        public void Configure(EntityTypeBuilder<Categoria_Plato> builder)
        {
            builder.ToTable("tb_CategoriaPlato");

            builder.HasKey(cp => cp.Id_CategoriaPlato);

            builder
                .HasMany(cp => cp.Platos)
                .WithOne(p => p.Categoria_Plato);

        }
    }
}