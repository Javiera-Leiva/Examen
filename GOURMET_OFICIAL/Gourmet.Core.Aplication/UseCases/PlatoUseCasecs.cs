using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class PlatoUseCase : IBaseUseCase<Plato, Guid>
    {
        private readonly IBaseRepository<Plato, Guid> repository;
        public PlatoUseCase(IBaseRepository<Plato, Guid> repository)
        {
            this.repository = repository;
        }

        public Plato Create(Plato entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                throw new Exception("Error El Plato no puede ser nulo");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Plato> GetAll()
        {
            return repository.GetAll();
        }

        public Plato GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Plato Update(Plato entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
