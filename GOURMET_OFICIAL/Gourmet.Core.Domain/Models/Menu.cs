using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gourmet.Core.Domain.Models
{
    public class Menu
    {
        public Guid Id_Menu { get; set; }
        public Guid Id_Bebida { get; set; }
        [ForeignKey("Id_Bebida")]
        public Bebida Bebida { get; set; }
        public Guid Id_Plato { get; set; }
        [ForeignKey("Id_Plato")]
        public Plato Plato { get; set; }

    }
}
