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
            return _context.Service.ToList();
        }

        public Service Get(int id)
        {
            return _context.Service.Find(id);
        }

        public void Add(Service entity)
        {
            _context.Service.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Service entity)
        {
            _context.Service.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Service entity)
        {
            _context.Service.Remove(entity);
            _context.SaveChanges();
        }
    }
}