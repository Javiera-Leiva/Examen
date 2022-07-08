using System;
using System.Collections.Generic;
using Gourmet.Core.Domain.Models;
using Gourmet.Core.Aplication.Interfaces;
using Gourmet.Core.Infraestructura.Repository.Abstract;

namespace Gourmet.Core.Aplication.UseCases
{
    public class UsuarioUseCase : IBaseUseCase<Usuario, Guid>
    {
        private readonly IBaseRepository<Usuario, Guid> repository;
        public UsuarioUseCase(IBaseRepository<Usuario, Guid> repository)
        {
            this.repository = repository;
        }

        public Usuario Create(Usuario entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
            {
                throw new Exception("Error , El usuario no esta siendo especificado");
            }
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Usuario> GetAll()
        {
            return repository.GetAll();
        }

        public Usuario GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Usuario Update(Usuario entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
