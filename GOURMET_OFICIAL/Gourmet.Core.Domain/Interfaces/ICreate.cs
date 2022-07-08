using System;
using System.Collections.Generic;
using System.Text;

namespace Gourmet.Core.Domain.Interfaces
{
    public interface ICreate<Entity>
    {
        Entity Create(Entity entity);
    }
}
