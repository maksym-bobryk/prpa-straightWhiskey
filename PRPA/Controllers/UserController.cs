using Microsoft.AspNetCore.Mvc;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepos;
         
        public UserController(IUserRepository userRepos)
        {
            this._userRepos = userRepos;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepos.GetAll();

            if(users.Count() == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("{idOrEmail}")]
        public IActionResult Get(string idOrEmail)
        {
            int id;
            if (int.TryParse(idOrEmail, out id))
            {
                var user = _userRepos.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            else
            {
                var client = _userRepos.Get(idOrEmail);

                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
        }


        /*        // GET api/<UserController>/5
                [HttpGet("id/{id}")]
                public IActionResult Get(int id)
                {
                    var user = _userRepos.Get(id);

                    if (user == null)
                    {
                        return NotFound();
                    }

                    return Ok(user);
                }

                [HttpGet("email/{email}")]
                public IActionResult Get(string email)
                {
                    var user = _userRepos.Get(email);

                    if (user == null)
                    {
                        return NotFound();
                    }

                    return Ok(user);
                }*/

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(user.UserId < 0)
            {
                return NotFound();
            }

            _userRepos.Add(user);

            return CreatedAtAction(nameof(Get), new { userId = user.UserId }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            var user = _userRepos.Get(id);

            if (user.UserId < 0)
            {
                return NotFound();
            }

            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            user.Name = updatedUser.Name;
            user.Phone = updatedUser.Phone;
            user.Photo = updatedUser.Photo;
            user.Role = updatedUser.Role;

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _userRepos.Get(id);

            if (user == null)
            {
                return;
            }

            _userRepos.Delete(user);
        }
    }
}
