using SalesQuery.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Data.Interface
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Find(Guid Id);
        void Add(Product entity);
        void Remove(Guid Id);

        // Future repository methods can be added here //
    }
}
