using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class PlatoRepository : IBaseRepository<Plato, Guid>
    {
        private PlantillaDB db;
        public PlatoRepository(PlantillaDB db)
        {
            this.db = db;
        }

        public Plato Create(Plato plato)
        {
            plato.Id_Plato = Guid.NewGuid();
            db.Platos.Add(plato);
            return plato;
        }

        public void Delete(Guid entityId)
        {
            var SelectedPlato = db.Platos
           .Where(p => p.Id_Plato == entityId).FirstOrDefault();
            if (SelectedPlato != null)
                db.Platos.Remove(SelectedPlato);
        }

        public List<Plato> GetAll()
        {
            return db.Platos.ToList();
        }

        public Plato GetById(Guid entityId)
        {
            var SelectedPlato = db.Platos
           .Where(p => p.Id_Plato == entityId).FirstOrDefault();
            return SelectedPlato;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Plato Update(Plato plato)
        {
            var selectedPlato = db.Platos
      .Where(p => p.Id_Plato == plato.Id_Plato).FirstOrDefault();

            if (selectedPlato != null)
            {
                selectedPlato.Id_Plato = plato.Id_Plato;
                selectedPlato.NombreP = plato.NombreP;
                selectedPlato.Precio = plato.Precio;
                selectedPlato.Descripcion = plato.Descripcion;
                selectedPlato.Fecha_Registro = plato.Fecha_Registro;
                

                db.Entry(selectedPlato).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedPlato;
        }
    }
}
