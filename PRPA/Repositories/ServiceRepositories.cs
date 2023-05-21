using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Service Get(int id)
        {
            return _context.Services.Find(id);
        }

        public void Add(Service entity)
        {
            _context.Services.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Service entity)
        {
            _context.Services.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Service entity)
        {
            _context.Services.Remove(entity);
            _context.SaveChanges();
        }
    }
}