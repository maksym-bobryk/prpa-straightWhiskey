using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class CosmeticsRequestRepository : ICosmeticsRequestRepository
    {
        private readonly AppDbContext _context;

        public CosmeticsRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CosmeticsRequest> GetAll()
        {
            return _context.CosmeticsRequests.ToList();
        }

        public CosmeticsRequest Get(int id)
        {
            return _context.CosmeticsRequests.Find(id);
        }

        public void Add(CosmeticsRequest entity)
        {
            _context.CosmeticsRequests.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CosmeticsRequest entity)
        {
            _context.CosmeticsRequests.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(CosmeticsRequest entity)
        {
            _context.CosmeticsRequests.Remove(entity);
            _context.SaveChanges();
        }
    }
}
