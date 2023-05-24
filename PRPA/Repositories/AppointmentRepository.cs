using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointment.ToList();
        }

        public Appointment Get(int id)
        {
            return _context.Appointment.Find(id);
        }

        public void Add(Appointment entity)
        {
            _context.Appointment.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Appointment entity)
        {
            _context.Appointment.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Appointment entity)
        {
            _context.Appointment.Remove(entity);
            _context.SaveChanges();
        }
    }
}