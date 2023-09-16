using FallLady.Mood.Domain.Domain.Transactions;
using FallLady.Mood.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Transactions
{
    public interface ITransactionRepository : IReadRepository<Transaction, int>, IWriteRepository<Transaction, int>, IQueryRepository<Transaction, int>, IDeleteRepository<Transaction, int>
    {
    }
}
