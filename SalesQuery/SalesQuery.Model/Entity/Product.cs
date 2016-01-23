using SalesQuery.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Model.Entity
{
    public class Product : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Other product details add more
        //Example Product Type, Category
    }
}
