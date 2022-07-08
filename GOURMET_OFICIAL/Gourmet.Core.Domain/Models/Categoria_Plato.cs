using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gourmet.Core.Domain.Models
{
    public class Categoria_Plato
    {
        public Guid Id_CategoriaPlato { get; set; }
        public string CategoriaP { get; set; }
        public List<Plato> Platos { get; set; }
    }
}
