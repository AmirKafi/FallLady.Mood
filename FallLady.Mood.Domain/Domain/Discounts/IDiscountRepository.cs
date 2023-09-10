using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Discounts
{
    public interface IDiscountRepository : IReadRepository<Discount, int>, IWriteRepository<Discount, int>, IQueryRepository<Discount, int>
    {

    }
}
