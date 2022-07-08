using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gourmet.Core.Domain.Models
{
     public class Detalle_Pedido
    {
        public Guid Id_Detalle_Pedido { get; set; }
        public Guid Id_Pedido { get; set; }
        [ForeignKey("Id_Pedido")]
        public Pedido_Venta Pedido_Venta { get; set; }
        public int Monto_total { get; set; }
        

    }
}
