using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gourmet.Core.Domain.Models
{
    public class Pedido_Venta
    {
        public Guid Id_Pedido { get; set; }
        public int Subtotal { get; set; }
        public int Cantidad_Platos{ get; set; }
        public int Cantidad_Bebidas { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public Guid Id_Usuario { get; set; }
        [ForeignKey("Id_Usuario")]
        public Usuario Usuario { get; set; }
        public Guid Id_Plato { get; set; }
        [ForeignKey("Id_Plato")]
        public Plato Plato { get; set; }
        public Guid Id_Bebida { get; set; }
        [ForeignKey("Id_Bebida")]
        public Bebida Bebida { get; set; }
        
        public List<Detalle_Pedido> Detalle_Pedidos { get; set; }

    }
}
