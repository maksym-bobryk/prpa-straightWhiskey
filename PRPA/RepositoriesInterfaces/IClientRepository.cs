using PRPA.Models;

namespace PRPA.RepositoriesInterfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Client Get(string email);
    }
}