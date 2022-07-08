using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gourmet.Core.Domain.Models
{
    public class Bebida
    {
        public Guid Id_Bebida { get; set; }

        public string NombreB { get; set; }

        public int Precio { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public Guid Id_CategoriaBebida { get; set; }
        [ForeignKey("Id_CategoriaBebida")]
        public Categoria_Bebida Categoria_Bebida { get; set; }
        public List<Menu> Menus { get; set; } 
        public List<Pedido_Venta> Pedido_Ventas { get; set; }



    }
}