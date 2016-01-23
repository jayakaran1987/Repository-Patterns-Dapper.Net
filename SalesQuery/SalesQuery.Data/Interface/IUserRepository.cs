using SalesQuery.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Data.Interface
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Find(Guid Id);
        void Add(User entity);
        void Update(User entity);
        void Remove(Guid Id);

        // Future repository methods can be added here //

    }
}
