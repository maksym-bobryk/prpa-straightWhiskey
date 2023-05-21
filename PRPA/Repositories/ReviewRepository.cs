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
            return _context.Reviews.ToList();
        }

        public Review Get(int id)
        {
            return _context.Reviews.Find(id);
        }

        public void Add(Review entity)
        {
            _context.Reviews.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Review entity)
        {
            _context.Reviews.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Review entity)
        {
            _context.Reviews.Remove(entity);
            _context.SaveChanges();
        }
    }
}
