using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;


namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class CtPlatoRepository : IBaseRepository<Categoria_Plato, Guid>
    {
        private PlantillaDB db;
        public CtPlatoRepository(PlantillaDB db)
        {
            this.db = db;
        }

        public Categoria_Plato Create(Categoria_Plato categoria_Plato)
        {
            categoria_Plato.Id_CategoriaPlato = Guid.NewGuid();
            db.Categoria_Platos.Add(categoria_Plato);
            return categoria_Plato;
        }

        public void Delete(Guid entityId)
        {
            var SelectedCPlato = db.Categoria_Platos
            .Where(Cp => Cp.Id_CategoriaPlato == entityId).FirstOrDefault();
            if (SelectedCPlato != null)
                db.Categoria_Platos.Remove(SelectedCPlato);
        }

        public List<Categoria_Plato> GetAll()
        {
            return db.Categoria_Platos.ToList();
        }

        public Categoria_Plato GetById(Guid entityId)
        {
            var SelectedCTPlato = db.Categoria_Platos
        .Where(Cp => Cp.Id_CategoriaPlato == entityId).FirstOrDefault();
            return SelectedCTPlato;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Categoria_Plato Update(Categoria_Plato categoria_Plato)
        {
            var selectedCTPlato = db.Categoria_Platos
            .Where(b => b.Id_CategoriaPlato == categoria_Plato.Id_CategoriaPlato).FirstOrDefault();

            if (selectedCTPlato != null)
            {
                
                selectedCTPlato.CategoriaP = categoria_Plato.CategoriaP;


                db.Entry(selectedCTPlato).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedCTPlato;
        }
    }
 }


