using FallLady.Mood.Domain.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Transactions
{
    public class TransactionRepository:CrudRepository<Transaction,int>,ITransactionRepository
    {
        public async Task<IEnumerable<Transaction>> GetList(int skip = 0, int take = 10)
        {
            return await _dbContext.Transactions
                                   .Include(x => x.Orders)
                                   .ThenInclude(x => x.Course)
                                   .Skip(take * skip)
                                   .Take(take)
                                   .AsNoTracking()
                                   .OrderByDescending(t => t.Id)
                                   .ToListAsync();
        }
        public async Task<Transaction> Get(int id)
        {
            var result =await _dbContext.Transactions
                                   .Include(x => x.Orders)
                                   .ThenInclude(x=> x.Course)
                                   .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
