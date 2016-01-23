using System;
using NUnit.Framework;
using SalesQuery.Model.Entity;
using SalesQuery.Data.Repository;
using SalesQuery.Data.Interface;

namespace SalesQuery.Test
{
    [TestFixture]
    public class PricingQueryRepositoryTest
    {
        //Note
        // We can write more test cases based on each functional areas.
        // Example - Each repositories, services like Send mail and Etc
    

        // Initialize repositories
        private IUserRepository userRepository;
        private IProductRepository productRepository;
        private IPricingQueryRepository pricingQueryRepository;

        [SetUp]
        public void SetUp()
        {
            this.userRepository = new UserRepository();
            this.productRepository = new ProductRepository();
            this.pricingQueryRepository = new PricingQueryRepository();
        }
        [Test]
        public void AddPricingQueryTest()
        {
            // We use a static id, so we always can drop the the user after the test
            Guid userid = new Guid("f265ab67-8006-4266-b6fd-c6a409321b31");

            // We use a static id, so we always can drop the the query after the test
            Guid queryid = new Guid("329BF626-9F06-483B-AD0F-F70E27BE30F7");

            // We use a static id, so we always can drop the the query after the test
            Guid productid = new Guid("758c0953-e576-4a8d-9223-b85ffd24c8ac");
            
            
            //Add User
            User user = new User() { Id = userid, FirstName = "Jayakaran", LastName = "Theiven", AddressLine1 = "buntspechtweg 8a", City = "Bonn", PostCode = "53123", Country = "Germany", Email ="t.jayakaran@yahoo.com", Phone = "00491739476008"};
            userRepository.Add(user);

            //Add Product
            Product product = new Product() { Id = productid, Name = "Test Product" };
            productRepository.Add(product);

            //insert pricing query
            PricingQuery query = new PricingQuery() { Id = queryid, ProductId = productid, UserId = userid, EnquiryDate = DateTime.Today, IsReplied = false };
            pricingQueryRepository.Add(query);

            // return pricing query data and test

            var result = pricingQueryRepository.Find(queryid);
            Assert.That(result.Id, Is.EqualTo(queryid));
            Assert.That(result.UserId, Is.EqualTo(userid));
            Assert.That(result.ProductId, Is.EqualTo(productid));

            //Clean up after testing
            PricingQueryCleanUp(queryid);
            UserCleanUp(userid);
            ProductCleanUp(productid);
        }

        //Clean up codes
        private void UserCleanUp(Guid Id)
        {
            var result = userRepository.Find(Id);

            if (result != null)
            {
                userRepository.Remove(Id);
            }
        }
        //Clean up codes
        private void PricingQueryCleanUp(Guid Id)
        {
            var result = pricingQueryRepository.Find(Id);

            if (result != null)
            {
                pricingQueryRepository.Remove(Id);
            }
        }
        //Clean up codes
        private void ProductCleanUp(Guid Id)
        {
            var result = productRepository.Find(Id);

            if (result != null)
            {
                productRepository.Remove(Id);
            }
        }

        //Note
        // We can write more test cases based on each functional areas.
        // Example - Each repositories, services like Send mail and Etc
    }
}
