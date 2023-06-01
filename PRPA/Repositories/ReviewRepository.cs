using Microsoft.EntityFrameworkCore;
using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Review.Include(b => b.Appointment).ToList();
        }

        public Review Get(int id)
        {
            return _context.Review.Where(b => b.ReviewId == id).Include(b => b.Appointment).FirstOrDefault();
        }

        public IEnumerable<Review> GetReviewsForBarber(int barberId)
        {
            var reviews = _context.Review
            .Where(p => p.Appointment.Barber.BarberId == barberId)
            .Include(b => b.Appointment.Barber)
            .Include(b => b.Appointment.Client)
            .ToList();

            return reviews;
        }

        public void Add(Review entity)
        {
            _context.Review.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Review entity)
        {
            _context.Review.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Review entity)
        {
            _context.Review.Remove(entity);
            _context.SaveChanges();
        }
    }
}
