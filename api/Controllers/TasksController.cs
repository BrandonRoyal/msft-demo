using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Providers;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private IDataAccess _dataAccess;

        public TasksController(){
            _dataAccess = new DataAccess();
        }

        public TasksController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET api/tasks
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tasks
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
