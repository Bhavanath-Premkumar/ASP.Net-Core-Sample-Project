using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<string> users = new List<string>() { "Arun", "Vel", "Ram", "Prabu", "Vicky" };

        [HttpGet]
        public IActionResult GetUsers()
        {
            if (users != null && users.Count > 0)
                return Ok(users);

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return id >= 0 && id < users.Count ? Ok(users[id]) : NotFound();
        }

        [HttpPost]
        public IActionResult AddUser(string user)
        {
            if (!string.IsNullOrEmpty(user))
                users.Add(user);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, string user)
        {
            if (id >= 0 && id < users.Count && !string.IsNullOrEmpty(user))
                users[id] = user;

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            if(id >=0 && id < users.Count) users.RemoveAt(id);

            return NoContent();
        }
    }
}
