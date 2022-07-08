using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Gourmet.Core.Domain.Models
{
    public class Administrador
    {
        public Guid Id_Admin { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_Registro { get; set; }

      
    }
}
