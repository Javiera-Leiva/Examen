using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Interfaces;


namespace Gourmet.Core.Infraestructura.Repository.Abstract
{
    public interface IBaseRepository<Entity, EntityId> : ICreate<Entity>,
       IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>, ITransaction
    {

    }
}

