using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class MenuUseCase : IBaseUseCase<Menu, Guid>
    {
        private readonly IBaseRepository<Menu, Guid> repository;
        public MenuUseCase(IBaseRepository<Menu, Guid> repository)
        {
            this.repository = repository;
        }

        public Menu Create(Menu entity)
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

        public List<Menu> GetAll()
        {
            return repository.GetAll();
        }

        public Menu GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Menu Update(Menu entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
