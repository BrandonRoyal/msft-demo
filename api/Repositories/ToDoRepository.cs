using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using api.Models;
using api.Providers;

namespace api.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private IDbContext _context;
        public ToDoRepository(IDbContext context)
        {
            _context = context;
        }

        public bool AddToDo(string userId, ToDo toDo)
        {
            var userStr = _context.Get(userId);
            var user = JsonConvert.DeserializeObject<User>(userStr);
            if (user != null)
            {
                user.ToDos.Add(toDo);
                _context.Set(userId, JsonConvert.SerializeObject(user));
                return true;
            }
            return false;
        }

        public bool RemoveToDo(string userId, int toDoId)
        {
            var userStr = _context.Get(userId);
            var user = JsonConvert.DeserializeObject<User>(userStr);
            if (user != null)
            {
                var toDo = user.ToDos.First(x => x.Id == toDoId);
                user.ToDos.Remove(toDo);
                _context.Set(userId, JsonConvert.SerializeObject(user));
                return true;
            }
            return false;
        }
    }

    public interface IToDoRepository
    {
        bool AddToDo(string userId, ToDo toDo);
        bool RemoveToDo(string userId, int toDoId);
    }
}