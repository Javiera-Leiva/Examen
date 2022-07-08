using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class CategoriaBUseCase : IBaseUseCase<Categoria_Bebida, Guid>
    {
        private readonly IBaseRepository<Categoria_Bebida, Guid> repository;
        public CategoriaBUseCase(IBaseRepository<Categoria_Bebida, Guid> repository)
        {
            this.repository = repository;
        }

        public Categoria_Bebida Create(Categoria_Bebida entity)
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

        public List<Categoria_Bebida> GetAll()
        {
            return repository.GetAll();
        }

        public Categoria_Bebida GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Categoria_Bebida Update(Categoria_Bebida entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
