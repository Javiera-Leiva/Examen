using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class EPlato : IEntityTypeConfiguration<Plato>
    {
        public void Configure(EntityTypeBuilder<Plato> builder)
        {
            builder.ToTable("tb_Plato");

            builder.HasKey(p => p.Id_Plato);

            builder
                .HasMany(p => p.Menus)
                .WithOne(men => men.Plato);


        }
    }
}
