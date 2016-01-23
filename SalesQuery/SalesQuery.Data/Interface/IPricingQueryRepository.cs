using SalesQuery.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Data.Interface
{
    public interface IPricingQueryRepository
    {
        List<PricingQuery> GetAll();
        void Add(PricingQuery entity);
        PricingQuery Find(Guid Id);
        void Remove(Guid Id);

        // Future repository methods can be added here //

    }
}
