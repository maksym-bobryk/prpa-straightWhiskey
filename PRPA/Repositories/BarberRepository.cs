using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private readonly AppDbContext _context;

        public BarberRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Barber> GetAll()
        {
            return _context.Barber.ToList();
        }

        public Barber Get(int id)
        {
            return _context.Barber.Find(id);
        }

        public void Add(Barber entity)
        {
            _context.Barber.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Barber entity)
        {
            _context.Barber.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Barber entity)
        {
            _context.Barber.Remove(entity);
            _context.SaveChanges();
        }
    }
}