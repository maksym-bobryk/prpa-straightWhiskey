using Microsoft.AspNetCore.Mvc;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepos;
        private readonly IBarberRepository _barberRepos;
        private readonly IClientRepository _clientRepos;

        public AppointmentController(IBarberRepository barberRepos, IAppointmentRepository appointmentRepos, IClientRepository reviewRepos)
        {
            this._barberRepos = barberRepos;
            this._appointmentRepos = appointmentRepos;
            this._clientRepos = reviewRepos;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var appointments = _appointmentRepos.GetAll().ToList();

            if (appointments.Count == 0)
            {
                return NotFound();
            }

            return Ok(appointments);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var appointment = _appointmentRepos.Get(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Appointment appointment)
        {
            if (appointment.AppointmentId < 0)
            {
                return NotFound();
            }

            _appointmentRepos.Add(appointment);

            return CreatedAtAction(nameof(Get), new { userId = appointment.AppointmentId }, appointment);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Appointment updatedAppointment)
        {
            var appointment = _appointmentRepos.Get(id);

            if (appointment.AppointmentId < 0)
            {
                return NotFound();
            }

            appointment.Barber = updatedAppointment.Barber;
            appointment.Client = updatedAppointment.Client;
            appointment.AppointmentTime = updatedAppointment.AppointmentTime;
            appointment.Services = updatedAppointment.Services;
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Appointment appointment = _appointmentRepos.Get(id);

            if (appointment == null)
            {
                return;
            }

            _appointmentRepos.Delete(appointment);
        }
    }
}
