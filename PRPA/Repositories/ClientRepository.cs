using PRPA.DBContext;
using PRPA.Models;
using PRPA.RepositoriesInterfaces;

namespace PRPA.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Client.ToList();
        }

        public Client Get(int id)
        {
            return _context.Client.Find(id);
        }

        public void Add(Client entity)
        {
            _context.Client.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Client entity)
        {
            _context.Client.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Client entity)
        {
            _context.Client.Remove(entity);
            _context.SaveChanges();
        }
    }
}