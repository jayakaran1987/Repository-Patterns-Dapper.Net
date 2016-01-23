using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Model.Core
{
    public interface IEntityBase
    {
        // common properties
        // Like Id, timestamp 
        Guid Id { get; set; }
    }
}
