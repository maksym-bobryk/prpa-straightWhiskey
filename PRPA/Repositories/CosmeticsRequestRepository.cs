using Microsoft.EntityFrameworkCore;
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
            return _context.CosmeticsRequest.Include(b => b.Barber).ToList();
        }

        public CosmeticsRequest Get(int id)
        {
            return _context.CosmeticsRequest.Where(b => b.CosmeticsRequestId == id).Include(b => b.Barber).FirstOrDefault();
        }

        public void Add(CosmeticsRequest entity)
        {
            _context.CosmeticsRequest.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CosmeticsRequest entity)
        {
            _context.CosmeticsRequest.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(CosmeticsRequest entity)
        {
            _context.CosmeticsRequest.Remove(entity);
            _context.SaveChanges();
        }
    }
}
