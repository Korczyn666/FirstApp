using System.Collections.Generic;
using System.Threading.Tasks;
using FirstApp.API.helpers;
using FirstApp.API.Models;

namespace FirstApp.API.Data
{
    public interface IDatingRepository
    {
         void add<T>(T entinty) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<PagedList<User>> GetUsers(UserParams userParams);
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
         Task<Like> GetLike(int userId, int recipientId);
    }
}