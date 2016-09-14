using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private IToDoRepository _repo;

        public ToDoController(IToDoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("{id}")]
        public IActionResult Post(string id, [FromBody] ToDo todo)
        {
            var success = _repo.AddToDo(id, todo);
            if (!success) return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ToDo todo)
        {
            var success = _repo.AddToDo(id, todo);
            if (!success) return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromBody] ToDo todo)
        {
            if (todo == null) return BadRequest();
            var success = _repo.RemoveToDo(id, todo.Id);
            if (!success) return BadRequest();
            return Ok();
        }
    }
}