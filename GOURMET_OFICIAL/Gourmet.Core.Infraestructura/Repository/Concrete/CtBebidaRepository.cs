using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;


namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class CtBebidaRepository : IBaseRepository<Categoria_Bebida, Guid>
    {
        private PlantillaDB db;
        public CtBebidaRepository(PlantillaDB db)
        {
            this.db = db;
        }

        public Categoria_Bebida Create(Categoria_Bebida categoria_Bebida)
        {
            categoria_Bebida.Id_CategoriaBebida = Guid.NewGuid();
            db.Categoria_Bebidas.Add(categoria_Bebida);
            return categoria_Bebida;
        }

        public void Delete(Guid entityId)
        {
            var SelectedCTBebida = db.Categoria_Bebidas
      .Where(Cb => Cb.Id_CategoriaBebida == entityId).FirstOrDefault();
            if (SelectedCTBebida != null)
                db.Categoria_Bebidas.Remove(SelectedCTBebida);
        }

        public List<Categoria_Bebida> GetAll()
        {
            return db.Categoria_Bebidas.ToList();
        }

        public Categoria_Bebida GetById(Guid entityId)
        {
            var SelectedCTBebida = db.Categoria_Bebidas
         .Where(Cb => Cb.Id_CategoriaBebida == entityId).FirstOrDefault();
            return SelectedCTBebida;
        }

        public void saveAllChanges()
        {

            db.SaveChanges();
        }

        public Categoria_Bebida Update(Categoria_Bebida categoria_Bebida)
        {
            var selectedCTBebida = db.Categoria_Bebidas
.Where(Cb => Cb.Id_CategoriaBebida == categoria_Bebida.Id_CategoriaBebida).FirstOrDefault();

            if (selectedCTBebida != null)
            {
                selectedCTBebida.Id_CategoriaBebida = categoria_Bebida.Id_CategoriaBebida;
                selectedCTBebida.CategoriaB = categoria_Bebida.CategoriaB;


                db.Entry(selectedCTBebida).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedCTBebida;
        }
    }
}

