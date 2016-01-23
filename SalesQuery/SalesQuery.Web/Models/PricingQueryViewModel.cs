using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesQuery.Web.Models
{
    public class PricingQueryViewModel
    {
        // View Model for Pricing Query Views 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public IEnumerable<Guid> SelectedProductIds { get; set; }
    }
}