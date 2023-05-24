using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User Get(int id)
        {
            return _context.User.Find(id);
        }

        public void Add(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.User.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.User.Remove(entity);
            _context.SaveChanges();
        }
    }
}