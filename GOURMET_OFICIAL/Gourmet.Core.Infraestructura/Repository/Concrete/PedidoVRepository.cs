using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class PedidoVRepository : IBaseRepository<Pedido_Venta, Guid>
    {
        private PlantillaDB db;
        public PedidoVRepository(PlantillaDB db)
        {
            this.db = db;
        }
        public Pedido_Venta Create(Pedido_Venta pedido_Venta)
        {
            pedido_Venta.Id_Pedido = Guid.NewGuid();
            db.Pedido_Ventas.Add(pedido_Venta);
            return pedido_Venta;
        }

        public void Delete(Guid entityId)
        {
            var SelectePedidoV = db.Pedido_Ventas
            .Where(Pv => Pv.Id_Pedido == entityId).FirstOrDefault();
            if (SelectePedidoV != null)
                db.Pedido_Ventas.Remove(SelectePedidoV);
        }

        public List<Pedido_Venta> GetAll()
        {
            return db.Pedido_Ventas.ToList();
        }

        public Pedido_Venta GetById(Guid entityId)
        {
            var SelectedPedidoV = db.Pedido_Ventas
       .Where(Pv => Pv.Id_Pedido == entityId).FirstOrDefault();
            return SelectedPedidoV;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Pedido_Venta Update(Pedido_Venta pedido_Venta)
        {
            var SelectedPedidoV = db.Pedido_Ventas
            .Where(Pv => Pv.Id_Pedido == pedido_Venta.Id_Pedido).FirstOrDefault();

            if (SelectedPedidoV != null)
            {
                SelectedPedidoV.Id_Pedido = SelectedPedidoV.Id_Pedido;
                SelectedPedidoV.Id_Plato = SelectedPedidoV.Id_Plato;
                SelectedPedidoV.Id_Bebida = SelectedPedidoV.Id_Bebida;
                SelectedPedidoV.Id_Usuario = SelectedPedidoV.Id_Usuario;
                db.Entry(SelectedPedidoV).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return SelectedPedidoV;
        }
    }
}
