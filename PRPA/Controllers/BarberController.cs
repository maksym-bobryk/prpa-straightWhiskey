using Microsoft.AspNetCore.Mvc;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        private readonly IBarberRepository _barberRepos;
        private readonly IAppointmentRepository _appointmentRepos;
        private readonly IReviewRepository _reviewRepos;

        public BarberController(IBarberRepository barberRepos, IAppointmentRepository appointmentRepos, IReviewRepository reviewRepos)
        {
            this._barberRepos = barberRepos;
            this._appointmentRepos = appointmentRepos;
            this._reviewRepos = reviewRepos;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var barbers = _barberRepos.GetAll();

            if (barbers.Count() == 0)
            {
                return NotFound();
            }

            return Ok(barbers);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var barber = _barberRepos.Get(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        // GET api/<UserController>/
        [HttpGet("{id}/reviews")]
        public IActionResult GetAllReviewsOfBarber(int id)
        {
            try
            {
                var reviews = _reviewRepos.GetReviewsForBarber(id);

                if (reviews == null || !reviews.Any())
                {
                    return NotFound();
                }

                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Barber barber)
        {
            if (barber.BarberId < 0)
            {
                return NotFound();
            }

            _barberRepos.Add(barber);

            return CreatedAtAction(nameof(Get), new { userId = barber.BarberId }, barber);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Barber updatedBarber)
        {
            var barber = _barberRepos.Get(id);

            if (barber.BarberId < 0)
            {
                return NotFound();
            }

            barber.Earnings = updatedBarber.Earnings;
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Barber barber = _barberRepos.Get(id);

            if (barber == null)
            {
                return;
            }

            _barberRepos.Delete(barber);
        }
    }
}
