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
            return _context.Appointments.ToList();
        }

        public Appointment Get(int id)
        {
            return _context.Appointments.Find(id);
        }

        public void Add(Appointment entity)
        {
            _context.Appointments.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Appointment entity)
        {
            _context.Appointments.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Appointment entity)
        {
            _context.Appointments.Remove(entity);
            _context.SaveChanges();
        }
    }
}