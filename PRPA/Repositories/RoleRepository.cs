using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Role.ToList();
        }

        public Role Get(int id)
        {
            return _context.Role.Find(id);
        }

        public void Add(Role entity)
        {
            _context.Role.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Role entity)
        {
            _context.Role.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            _context.Role.Remove(entity);
            _context.SaveChanges();
        }
    }
}
