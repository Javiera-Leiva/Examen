using System;
using System.Collections.Generic;
using System.Text;

namespace Gourmet.Core.Domain.Interfaces
{
    public interface ITransaction
    {
        void saveAllChanges();
    }
}
