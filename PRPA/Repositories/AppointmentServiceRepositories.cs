using Microsoft.EntityFrameworkCore;
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
            return _context.AppointmentService.Include(b => b.Service).Include(b => b.Appointment).ToList();
        }

        public AppointmentService Get(int id)
        {
            return _context.AppointmentService.Where(b => b.AppointmentServiceId == id).Include(b => b.Service).Include(b => b.Appointment).FirstOrDefault();
        }

        public void Add(AppointmentService entity)
        {
            _context.AppointmentService.Add(entity);
            _context.SaveChanges();
        }

        public void Update(AppointmentService entity)
        {
            _context.AppointmentService.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(AppointmentService entity)
        {
            _context.AppointmentService.Remove(entity);
            _context.SaveChanges();
        }
    }
}