using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class AdminRepository : IBaseRepository<Administrador, Guid>
    {
        private PlantillaDB db;
        public AdminRepository(PlantillaDB db)
        {
            this.db = db;
        }

        public Administrador Create(Administrador administrador)
        {
            administrador.Id_Admin = Guid.NewGuid();
            db.Administradors.Add(administrador);
            return administrador;
        }

        public void Delete(Guid entityId)
        {

            var SelectedAdmin = db.Administradors
           .Where(A => A.Id_Admin == entityId).FirstOrDefault();
            if (SelectedAdmin != null)
                db.Administradors.Remove(SelectedAdmin);
        }

        public List<Administrador> GetAll()
        {
            return db.Administradors.ToList();
        }

        public Administrador GetById(Guid entityId)
        {
            var SelectedAdmin = db.Administradors
          .Where(A => A.Id_Admin == entityId).FirstOrDefault();
            return SelectedAdmin;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Administrador Update(Administrador administrador)
        {
            var selectedAdmin = db.Administradors
            .Where(A => A.Id_Admin == administrador.Id_Admin).FirstOrDefault();

            if (selectedAdmin != null)
            {
                selectedAdmin.Id_Admin = administrador.Id_Admin;
                selectedAdmin.Contraseña = administrador.Contraseña;
                selectedAdmin.Correo = administrador.Correo;
                selectedAdmin.Telefono = administrador.Telefono;
                selectedAdmin.Nombre = administrador.Nombre;
                selectedAdmin.Fecha_Registro = administrador.Fecha_Registro;



                db.Entry(selectedAdmin).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedAdmin;
        }
    }
}
