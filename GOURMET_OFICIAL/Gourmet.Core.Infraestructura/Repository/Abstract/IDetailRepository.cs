using System;
using System.Collections.Generic;
using System.Text;
using Gourmet.Core.Domain.Interfaces;

namespace Gourmet.Core.Infraestructura.Repository.Abstract
{
    public interface IDetailRepository<Entity, TransactionId> : ICreate<Entity>, ITransaction
    {
        List<Entity> GetDetailsByTransaction(TransactionId transactionId);
    }
}
    