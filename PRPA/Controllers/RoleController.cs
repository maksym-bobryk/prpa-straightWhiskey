using Microsoft.AspNetCore.Mvc;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepos;

        public RoleController(IRoleRepository roleRepos)
        {
            this._roleRepos = roleRepos;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var role = _roleRepos.GetAll();

            if (role.Count() == 0)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var role = _roleRepos.Get(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            if (role.RoleId < 0)
            {
                return NotFound();
            }

            _roleRepos.Add(role);

            return CreatedAtAction(nameof(Get), new { userId = role.RoleId }, role);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role updatedRole)
        {
            var role =_roleRepos.Get(id);

            if (role.RoleId < 0)
            {
                return NotFound();
            }

            role.AccessFlags = updatedRole.AccessFlags;
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Role role = _roleRepos.Get(id);

            if (role == null)
            {
                return;
            }

            _roleRepos.Delete(role);
        }
    }
}
