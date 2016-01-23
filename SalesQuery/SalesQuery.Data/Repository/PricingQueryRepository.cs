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
    public class PricingQueryRepository : IPricingQueryRepository
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

        public List<PricingQuery> GetAll()
        {
            using (IDbConnection cn = connection)
            {
                cn.Open();
                return cn.Query<PricingQuery>("SELECT * FROM PricingQuery").ToList();
            }
        }

         public void Add(PricingQuery entity)
         {
             using (IDbConnection cn = connection)
             {
                 var parameters = new
                 {
                     UserId = entity.UserId,
                     ProductId = entity.ProductId,
                     EnquiryDate = entity.EnquiryDate,
                     RespondedDate = entity.RespondedDate,
                     IsReplied = entity.IsReplied,
                     Id = entity.Id,
                 };

                 cn.Open();
                 entity.Id = cn.Query<Guid>(
                     "INSERT INTO PricingQuery (UserId, ProductId, EnquiryDate, RespondedDate, IsReplied, Id) VALUES(@UserId, @ProductId, @EnquiryDate, @RespondedDate, @IsReplied,  @Id)",
                     parameters).FirstOrDefault();
             }
         }


         public PricingQuery Find(Guid Id)
         {
             using (IDbConnection cn = connection)
             {
                 cn.Open();
                 return cn.Query<PricingQuery>("SELECT * FROM PricingQuery WHERE Id = @Id", new { Id }).SingleOrDefault();
             }
         }

         public void Remove(Guid Id)
         {
             using (IDbConnection cn = connection)
             {
                 cn.Open();
                 cn.Execute(
                     "DELETE FROM PricingQuery WHERE Id=@Id",
                     new { Id = Id });
             }
         }

        // Other repository methods can be added here
 
    }
}
