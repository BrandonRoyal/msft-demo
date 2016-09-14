using System.Collections.Generic;
using Newtonsoft.Json;
using api.Models;
using api.Providers;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDbContext _context;

        public UserRepository(IDbContext context)
        {
            _context = context;
        }

        public User Get(string userId)
        {
            var result = _context.Get(userId);
            if (string.IsNullOrEmpty(result)) return null; //user does not exist
            return JsonConvert.DeserializeObject<User>(result);
        }

        public User Create(string userId)
        {
            var result = _context.Get(userId);
            if (!string.IsNullOrEmpty(result)) return null; //user already exists
            var user = new User();
            user.Id = userId;
            user.ToDos = new List<ToDo>();
            var userStr = JsonConvert.SerializeObject(user);
            _context.Set(userId, userStr);
            return user;
        }

        public void Delete(string userId)
        {
            _context.Delete(userId);
        }
    }

    public interface IUserRepository
    {
        User Get(string userId);
        User Create(string userId);
        void Delete(string userId);
    }
}