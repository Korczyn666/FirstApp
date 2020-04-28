using System.Collections.Generic;
using System.Threading.Tasks;
using FirstApp.API.Models;

namespace FirstApp.API.Data
{
    public interface IDatingRepository
    {
         void add<T>(T entinty) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}