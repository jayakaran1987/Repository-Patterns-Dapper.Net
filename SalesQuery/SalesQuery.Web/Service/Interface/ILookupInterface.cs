using SalesQuery.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Web.Service.Interface
{
    interface ILookupInterface
    {
        List<LookupModel> GetProductLookups();
    }
}
