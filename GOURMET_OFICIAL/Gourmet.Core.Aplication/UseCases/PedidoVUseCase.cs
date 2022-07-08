using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class PedidoVUseCase : IBaseUseCase<Pedido_Venta, Guid>
    {
        private readonly IBaseRepository<Pedido_Venta, Guid> repository;
        public PedidoVUseCase(IBaseRepository<Pedido_Venta, Guid> repository)
        {
            this.repository = repository;
        }

        public Pedido_Venta Create(Pedido_Venta entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                throw new Exception("Error, El detalle del pedido no puede estar vacio ");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Pedido_Venta> GetAll()
        {
            return repository.GetAll();
        }

        public Pedido_Venta GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Pedido_Venta Update(Pedido_Venta entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
