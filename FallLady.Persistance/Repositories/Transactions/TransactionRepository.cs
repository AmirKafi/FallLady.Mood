using FallLady.Mood.Domain.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Transactions
{
    public class TransactionRepository:CrudRepository<Transaction,int>,ITransactionRepository
    {
    }
}
