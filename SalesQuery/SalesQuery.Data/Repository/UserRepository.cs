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
    public class UserRepository : IUserRepository
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


        public List<User> GetAll()
        {
            using (IDbConnection cn = connection)
            {
                cn.Open();
                return cn.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public User Find(Guid Id)
        {
            using (IDbConnection cn = connection)
            {
                cn.Open();
                return cn.Query<User>("SELECT * FROM Users WHERE Id = @Id", new { Id }).SingleOrDefault();
            }
        }

        public void Add(User entity)
        {
            using (IDbConnection cn = connection)
            {
                var parameters = new
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    AddressLine1 = entity.AddressLine1,
                    City = entity.City,
                    PostCode = entity.PostCode,
                    Country = entity.Country,
                    Phone = entity.Phone,
                    Id = entity.Id
                };

                cn.Open();
                entity.Id = cn.Query<Guid>(
                    "INSERT INTO Users (FirstName, LastName, Email, AddressLine1,City,PostCode,Country,Phone, Id) VALUES(@FirstName, @LastName, @Email, @AddressLine1,@City,@PostCode,@Country,@Phone, @Id)",
                    parameters).FirstOrDefault();
            }
        }

        public void Update(User entity)
        {
            using (IDbConnection cn = connection)
            {
                var parameters = new
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    AddressLine1 = entity.AddressLine1,
                    City = entity.City,
                    PostCode = entity.PostCode,
                    Country = entity.Country,
                    Phone = entity.Phone,
                    Id = entity.Id
                };

                cn.Open();
                cn.Execute(
                    "UPDATE Users SET FirstName=@FirstName, LastName=@LastName, Email=@Email, AddressLine1=@AddressLine1, City=@City, PostCode=@PostCode, Country=@Country, Phone = @Phone WHERE Id=@Id",
                    parameters);
            }
        }

        public void Remove(Guid Id)
        {
            using (IDbConnection cn = connection)
            {
                cn.Open();
                cn.Execute(
                    "DELETE FROM Users WHERE Id=@Id",
                    new { Id = Id });
            }
        }
    }
}
