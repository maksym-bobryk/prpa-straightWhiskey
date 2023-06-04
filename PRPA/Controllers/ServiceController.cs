using Microsoft.AspNetCore.Mvc;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepos;

        public ServiceController(IServiceRepository serviceRepos)
        {
            this._serviceRepos = serviceRepos;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var services = _serviceRepos.GetAll();

            if (services.Count() == 0)
            {
                return NotFound();
            }

            return Ok(services);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var service = _serviceRepos.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Service service)
        {
            service.Appointments = new List<Appointment>();
            _serviceRepos.Add(service);

            return CreatedAtAction(nameof(Get), new { userId = service.ServiceId }, service);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service updatedService)
        {
            var service = _serviceRepos.Get(id);

            if (service.ServiceId < 0)
            {
                return NotFound();
            }

            service.Name = updatedService.Name;
            service.Duration = updatedService.Duration;
            service.Cost = updatedService.Cost;
            service.Description = updatedService.Description;
            service.Appointments = updatedService.Appointments;
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Service service = _serviceRepos.Get(id);

            if (service == null)
            {
                return;
            }

            _serviceRepos.Delete(service);
        }
    }
}
