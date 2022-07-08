using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;


namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class MenuRepository : IBaseRepository<Menu, Guid>
    {

        private PlantillaDB db;
        public MenuRepository(PlantillaDB db)
        {
            this.db = db;
        }
        public Menu Create(Menu menu)
        {
            menu.Id_Menu = Guid.NewGuid();
            db.Menus.Add(menu);
            return menu;
        }

        public void Delete(Guid entityId)
        {
            var SelectedMenu= db.Menus
            .Where(M => M.Id_Menu == entityId).FirstOrDefault();
            if (SelectedMenu != null)
                db.Menus.Remove(SelectedMenu);
        }

        public List<Menu> GetAll()
        {
            return db.Menus.ToList();
        }

        public Menu GetById(Guid entityId)
        {
            var SelectedMenu = db.Menus
          .Where(M => M.Id_Menu == entityId).FirstOrDefault();
            return SelectedMenu;
        }

        public void saveAllChanges()
        {
             db.SaveChanges();      
        }

        public Menu Update(Menu menu)
        {
            var SelectedMenu = db.Menus
      .Where(M => M.Id_Menu == menu.Id_Menu).FirstOrDefault();

            if (SelectedMenu != null)
            {
                SelectedMenu.Id_Menu= SelectedMenu.Id_Menu;
                SelectedMenu.Id_Plato = SelectedMenu.Id_Plato;
                SelectedMenu.Id_Bebida = SelectedMenu.Id_Bebida;

                db.Entry(SelectedMenu).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return SelectedMenu;
        }
    }
}
