using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Gourmet.Core.Domain.Models
{
    public class Usuario
    {
        public Guid Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_Registro { get; set; }
       
        public List<Pedido_Venta> Pedido_Ventas { get; set; }
    }
}
