using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Interfaces;


namespace Gourmet.Core.Aplication.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {

    }
}
