using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class AppointmentServiceRepository : IAppointmentServiceRepository
    {
        private readonly AppDbContext _context;

        public AppointmentServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AppointmentService> GetAll()
        {
            return _context.AppointmentServices.ToList();
        }

        public AppointmentService Get(int id)
        {
            return _context.AppointmentServices.Find(id);
        }

        public void Add(AppointmentService entity)
        {
            _context.AppointmentServices.Add(entity);
            _context.SaveChanges();
        }

        public void Update(AppointmentService entity)
        {
            _context.AppointmentServices.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(AppointmentService entity)
        {
            _context.AppointmentServices.Remove(entity);
            _context.SaveChanges();
        }
    }
}