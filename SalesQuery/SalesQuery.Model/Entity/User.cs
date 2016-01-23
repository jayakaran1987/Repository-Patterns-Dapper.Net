using SalesQuery.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Model.Entity
{
    public class User : IEntityBase
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        // Country could come from Lookup table
        public string Country { get; set; }

        public string Phone { get; set; }
    }
}
