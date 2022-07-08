using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gourmet.Core.Domain.Models
{
    public class Plato
    {
        public Guid Id_Plato { get; set; }
        public string NombreP { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public Guid Id_CategoriaPlato { get; set; }
        [ForeignKey("Id_CategoriaPlato")]
        public Categoria_Plato Categoria_Plato { get; set; }
        public List<Menu> Menus { get; set; }

        public List<Pedido_Venta> Pedido_Ventas { get; set; }



    }
}
