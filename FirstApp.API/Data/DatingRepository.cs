using System.Collections.Generic;
using System.Threading.Tasks;
using FirstApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
        {
            _context = context;
        }
        public void add<T>(T entinty) where T : class
        {
            _context.Add(entinty);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
           return await _context.Photos.SingleOrDefaultAsync(p => p.UserId == userId && p.IsMain == true);
        }

        public async Task<Photo> GetPhoto(int id)
        {
           var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
           
           return photo;
        }

        public async Task<User> GetUser(int id)
        {
           var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(user => user.Id == id);
           return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}