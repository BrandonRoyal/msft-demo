using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = _repo.Get(id);
            if (user == null) return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost("{id}")]
        public IActionResult Post(string id)
        {
            var user = _repo.Create(id);
            if (user != null) return new ObjectResult(user);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _repo.Delete(id);
            return new NoContentResult();
        }
    }
}