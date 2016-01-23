using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesQuery.Web.Models
{
    public class LookupModel
    {
        // View Model for Lookups
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}