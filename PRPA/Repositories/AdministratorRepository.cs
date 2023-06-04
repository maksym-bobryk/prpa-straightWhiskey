using Microsoft.EntityFrameworkCore;
using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly AppDbContext _context;

        public AdministratorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Administrator> GetAll()
        {
            return _context.Administrator.Include(b => b.User).ToList();
        }

        public Administrator Get(int id)
        {
            return _context.Administrator.Where(b => b.AdministratorId == id).Include(b => b.User).FirstOrDefault();
        }

        public Administrator Get(string email)
        {
            return _context.Administrator.Where(x => x.User.Email == email).Include(x => x.User).ThenInclude(b => b.Role).FirstOrDefault();
        }


        public void Add(Administrator entity)
        {
            _context.Administrator.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Administrator entity)
        {
            _context.Administrator.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Administrator entity)
        {
            _context.Administrator.Remove(entity);
            _context.SaveChanges();
        }
    }
}