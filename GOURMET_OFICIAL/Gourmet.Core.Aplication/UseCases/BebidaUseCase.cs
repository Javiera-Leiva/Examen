using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class BebidaUseCase : IBaseUseCase<Bebida, Guid>
    {
        private readonly IBaseRepository<Bebida, Guid> repository;
        public BebidaUseCase(IBaseRepository<Bebida, Guid> repository)
        {
            this.repository = repository;
        }

        public Bebida Create(Bebida entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                throw new Exception("Error La Bebida no puede ser nulo");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Bebida> GetAll()
        {
            return repository.GetAll();
        }

        public Bebida GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Bebida Update(Bebida entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
