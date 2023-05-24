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
            return _context.Review.ToList();
        }

        public Review Get(int id)
        {
            return _context.Review.Find(id);
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
