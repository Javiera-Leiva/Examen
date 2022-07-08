using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Infraestructura.Repository.Abstract;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;
namespace Gourmet.Core.Infraestructura.Repository.Concrete
{
    public class DtPedidoRepository : IBaseRepository<Detalle_Pedido, Guid>
    {
        private PlantillaDB db;
        public DtPedidoRepository(PlantillaDB db)
        {
            this.db = db;
        }

        public Detalle_Pedido Create(Detalle_Pedido detalle_Pedido)
        {
            detalle_Pedido.Id_Detalle_Pedido = Guid.NewGuid();
            db.Detalle_Pedidos.Add(detalle_Pedido);
            return detalle_Pedido;
        }

        public void Delete(Guid entityId)
        {
            var SelectedPedidoD = db.Detalle_Pedidos
             .Where(Dp => Dp.Id_Detalle_Pedido == entityId).FirstOrDefault();
            if (SelectedPedidoD != null)
                db.Detalle_Pedidos.Remove(SelectedPedidoD);
        }

        public List<Detalle_Pedido> GetAll()
        {
            return db.Detalle_Pedidos.ToList();
        }

        public Detalle_Pedido GetById(Guid entityId)
        {
            var SelectedPedidoD = db.Detalle_Pedidos
           .Where(Dp => Dp.Id_Detalle_Pedido == entityId).FirstOrDefault();
            return SelectedPedidoD;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Detalle_Pedido Update(Detalle_Pedido detalle_Pedido)
        {
            var SelectedPedidoD = db.Detalle_Pedidos
           .Where(a => a.Id_Detalle_Pedido == detalle_Pedido.Id_Detalle_Pedido).FirstOrDefault();

            if (SelectedPedidoD != null)
            {
                SelectedPedidoD.Id_Detalle_Pedido = SelectedPedidoD.Id_Detalle_Pedido;
                SelectedPedidoD.Id_Pedido = SelectedPedidoD.Id_Pedido;
                SelectedPedidoD.Monto_total = SelectedPedidoD.Monto_total;

                db.Entry(SelectedPedidoD).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return SelectedPedidoD;
        }
    }

}