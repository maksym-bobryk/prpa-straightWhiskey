using Microsoft.EntityFrameworkCore;
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
            return _context.User.Include(b => b.Role).ToList();
        }

        public User Get(int id)
        {
            return _context.User.Where(b => b.UserId == id).Include(b => b.Role).FirstOrDefault();
        }

        public User Get(string email)
        {
            return _context.User.Where(x => x.Email == email).FirstOrDefault();
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