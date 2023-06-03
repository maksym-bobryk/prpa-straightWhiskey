using PRPA.Models;

namespace PRPA.RepositoriesInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string email);
    }
}