using PRPA.Models;

namespace PRPA.RepositoriesInterfaces
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Administrator Get(string email);
    }
}