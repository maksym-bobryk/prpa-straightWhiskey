using Microsoft.AspNetCore.Mvc;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepos;

        public ClientController(IClientRepository clientRepos)
        {
            this._clientRepos = clientRepos;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var client = _clientRepos.GetAll();

            if (client.Count() == 0)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // GET api/<UserController>/5
        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            var client = _clientRepos.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpGet("email/{email}")]
        public IActionResult Get(string email)
        {
            var client = _clientRepos.Get(email);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            if (client.ClientId < 0)
            {
                return NotFound();
            }

            _clientRepos.Add(client);

            return CreatedAtAction(nameof(Get), new { userId = client.ClientId }, client);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client updatedClient)
        {
            var client = _clientRepos.Get(id);

            if (client.ClientId < 0)
            {
                return NotFound();
            }

            client.User = updatedClient.User;
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Client client = _clientRepos.Get(id);

            if (client == null)
            {
                return;
            }

            _clientRepos.Delete(client);
        }
    }
}
