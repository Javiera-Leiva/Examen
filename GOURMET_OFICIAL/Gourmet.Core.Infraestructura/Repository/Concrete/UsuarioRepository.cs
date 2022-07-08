using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class UsuarioRepository : IBaseRepository<Usuario, Guid>
    {
        private PlantillaDB db;
        public UsuarioRepository(PlantillaDB db)
        {
            this.db = db;
        }

        public Usuario Create(Usuario usuario)
        {
            usuario.Id_Usuario = Guid.NewGuid();
            db.Usuarios.Add(usuario);
            return usuario;
        }

        public void Delete(Guid entityId)
        {
            var SelectedUsuario = db.Usuarios
            .Where(U => U.Id_Usuario == entityId).FirstOrDefault();
            if (SelectedUsuario != null)
                db.Usuarios.Remove(SelectedUsuario);
        }

        public List<Usuario> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public Usuario GetById(Guid entityId)
        {
            var SelectedUsuario = db.Usuarios
            .Where(U => U.Id_Usuario == entityId).FirstOrDefault();
            return SelectedUsuario;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Usuario Update(Usuario usuario)
        {
            var selectedUsuario = db.Usuarios
  .Where(U => U.Id_Usuario == usuario.Id_Usuario).FirstOrDefault();

            if (selectedUsuario != null)
            {
                selectedUsuario.Id_Usuario = selectedUsuario.Id_Usuario;
                selectedUsuario.Nombre = selectedUsuario.Nombre;
                selectedUsuario.Correo = selectedUsuario.Correo;
                selectedUsuario.Telefono = selectedUsuario.Telefono;
                selectedUsuario.Fecha_Registro = selectedUsuario.Fecha_Registro;

                db.Entry(selectedUsuario).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedUsuario;
        }
    }
 }
