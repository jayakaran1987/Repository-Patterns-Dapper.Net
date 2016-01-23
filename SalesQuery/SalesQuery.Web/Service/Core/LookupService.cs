using SalesQuery.Data.Interface;
using SalesQuery.Data.Repository;
using SalesQuery.Web.Models;
using SalesQuery.Web.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesQuery.Web.Service
{
    public class LookupService : ILookupInterface
    {
        private readonly IProductRepository productRepository;

        public LookupService()
        {
            // initialization
            // Replace this with IoC 
            // Can Use TinyIoc, Unity, Ninject, Autofac etc
            productRepository = new ProductRepository();
        }
        public List<LookupModel> GetProductLookups()
        {
            var result = new List<LookupModel>();

            var qry = from item in productRepository.GetAll()
                      select new LookupModel()
                      {
                          Id = item.Id,
                          Name = item.Name,
                      };

            return qry.ToList(); ;
        }

        // Add more lookups
        // Example GetCountryLookup, etc
    }
}