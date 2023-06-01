using Microsoft.AspNetCore.Mvc;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepos;

        public ReviewController(IReviewRepository reviewRepos)
        {
            this._reviewRepos = reviewRepos;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var review = _reviewRepos.GetAll();

            if (review.Count() == 0)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _reviewRepos.Get(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            if (review.ReviewId < 0)
            {
                return NotFound();
            }

            _reviewRepos.Add(review);

            return CreatedAtAction(nameof(Get), new { userId = review.ReviewId }, review);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review updatedReview)
        {
            var review = _reviewRepos.Get(id);

            if (review.ReviewId < 0)
            {
                return NotFound();
            }

            review.Rating = updatedReview.Rating;
            review.Text = updatedReview.Text;
            review.Photo = updatedReview.Photo;
            review.Appointment = updatedReview.Appointment;
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Review review = _reviewRepos.Get(id);

            if (review == null)
            {
                return;
            }

            _reviewRepos.Delete(review);
        }
    }
}
