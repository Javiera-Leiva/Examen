using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class PedidoDUseCase : IBaseUseCase<Detalle_Pedido, Guid>
    {
        private readonly IBaseRepository<Detalle_Pedido, Guid> repository;
        public PedidoDUseCase(IBaseRepository<Detalle_Pedido, Guid> repository)
        {
            this.repository = repository;
        }

        public Detalle_Pedido Create(Detalle_Pedido entity)
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

        public List<Detalle_Pedido> GetAll()
        {
            return repository.GetAll();
        }

        public Detalle_Pedido GetById(Guid entityId)
        {
            return repository.GetById(entityId);    
        }

        public Detalle_Pedido Update(Detalle_Pedido entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
