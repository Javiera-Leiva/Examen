using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gourmet.Core.Domain.Models;

namespace Gourmet.Adaptors.SQLServerDataAccess.Entities
{
    public class EMenu : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("tb_Menu");

            builder.HasKey(men => new { men.Id_Menu, men.Id_Plato, men.Id_Bebida});

            builder
                .HasOne(men => men.Plato)
                .WithMany(p => p.Menus);

            builder
                .HasOne(men => men.Bebida)
                .WithMany(b => b.Menus);

        }
    }
}
