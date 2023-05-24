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
            return _context.Administrator.ToList();
        }

        public Administrator Get(int id)
        {
            return _context.Administrator.Find(id);
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