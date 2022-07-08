using System;
using System.Collections.Generic;
using System.Text;

namespace Gourmet.Core.Domain.Interfaces
{
    public interface IDelete<EntityId>
    {
        void Delete(EntityId entityId);
    }
}