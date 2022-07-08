using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

    namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class BebidaRepository : IBaseRepository<Bebida, Guid>
    {
        private PlantillaDB db;
        public BebidaRepository(PlantillaDB db)
        {
            this.db = db;
        }

        public Bebida Create(Bebida bebida  )
        {
            bebida.Id_Bebida = Guid.NewGuid();
            db.Bebidas.Add(bebida);
            return bebida;
        }

        public void Delete(Guid entityId)
        {
            var SelectedBebida = db.Bebidas
          .Where(b => b.Id_Bebida == entityId).FirstOrDefault();
            if (SelectedBebida != null)
                db.Bebidas.Remove(SelectedBebida);
        }

        public List<Bebida> GetAll()
        {
            return db.Bebidas.ToList();
        }

        public Bebida GetById(Guid entityId)
        {
            var SelectedBebida = db.Bebidas
         .Where(b => b.Id_Bebida == entityId).FirstOrDefault();
            return SelectedBebida;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Bebida Update(Bebida bebida)
        {
            var selectedBebida = db.Bebidas
.Where(b => b.Id_Bebida == bebida.Id_Bebida).FirstOrDefault();

            if (selectedBebida != null)
            {
                selectedBebida.Id_Bebida = bebida.Id_Bebida;
                selectedBebida.NombreB = bebida.NombreB;
                selectedBebida.Precio = bebida.Precio;
                selectedBebida.Fecha_Registro = bebida.Fecha_Registro;
       




                db.Entry(selectedBebida).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedBebida;
        }
    }
}
