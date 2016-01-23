using SalesQuery.Data.Interface;
using SalesQuery.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace SalesQuery.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        // Since considering a small repository operations I decided to use Dapper
        // Dapper is a micro-ORM: it does not offer the full range of features of a full ORM such as NHibernate or Entity Framework
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["SalesQueryConnectionString"].ConnectionString);
            }
        }

        public List<Product> GetAll()
        {
            using (IDbConnection cn = connection)
            {
                cn.Open();
                return cn.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public Product Find(Guid Id)
        {
            using (IDbConnection cn = connection)
            {
                cn.Open();
                return cn.Query<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id }).SingleOrDefault();
            }
        }

        public void Add(Product entity)
        {
            using (IDbConnection cn = connection)
            {
                var parameters = new
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                cn.Open();
                entity.Id = cn.Query<Guid>(
                    "INSERT INTO Products (Name, Id) VALUES(@Name, @Id)",
                    parameters).FirstOrDefault();
            }
        }

        public void Remove(Guid Id)
        {
            using (IDbConnection cn = connection)
            {
                cn.Open();
                cn.Execute(
                    "DELETE FROM Products WHERE Id=@Id",
                    new { Id = Id });
            }
        }
    }
}
