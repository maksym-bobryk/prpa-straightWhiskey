using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;
using System;

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
            return _context.Barbers.ToList();
        }

        public Barber Get(int id)
        {
            return _context.Barbers.Find(id);
        }

        public void Add(Barber entity)
        {
            _context.Barbers.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Barber entity)
        {
            _context.Barbers.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Barber entity)
        {
            _context.Barbers.Remove(entity);
            _context.SaveChanges();
        }
    }

}
