using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class AdminUseCase : IBaseUseCase<Administrador, Guid>
    {
        private readonly IBaseRepository<Administrador, Guid> repository;
        public AdminUseCase(IBaseRepository<Administrador, Guid> repository)
        {
            this.repository = repository;
        }

        public Administrador Create(Administrador entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                throw new Exception("Error , El Admin no esta siendo especificado");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Administrador> GetAll()
        {
            return repository.GetAll();
        }

        public Administrador GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Administrador Update(Administrador entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
