using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using api.Models;
using api.Providers;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {

        private IDbContext _context;

        public TasksController()
        {
            _context = new RedisDbContext();
        }

        // GET api/tasks
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"1", "2"};
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            //Convert.ToString(id)
            return _context.Get(id);
        }

        // POST api/tasks
        [HttpPost("{id}")]
        public void Post(string id, [FromBody]ToDo value)
        {
            var objStr = JsonConvert.SerializeObject(value);
            _context.Set(id, objStr);
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]ToDo value)
        {
            var objStr = JsonConvert.SerializeObject(value);            
            _context.Set(id, objStr);
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _context.Delete(id);
        }
    }
}
