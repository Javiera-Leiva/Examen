using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gourmet.Core.Domain.Models
{
    public class Categoria_Bebida
    {
        public Guid Id_CategoriaBebida { get; set; }
        public string CategoriaB { get; set; }
        public List<Bebida> Bebidas { get; set; }
    }
}
