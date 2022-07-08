using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class CategoriaPUseCase : IBaseUseCase<Categoria_Plato, Guid>
    {
        private readonly IBaseRepository<Categoria_Plato, Guid> repository;
        public CategoriaPUseCase(IBaseRepository<Categoria_Plato, Guid> repository)
        {
            this.repository = repository;
        }

        public Categoria_Plato Create(Categoria_Plato entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                throw new Exception("Error La Categoria no puede ser nulo");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Categoria_Plato> GetAll()
        {
            return repository.GetAll();
        }

        public Categoria_Plato GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Categoria_Plato Update(Categoria_Plato entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
