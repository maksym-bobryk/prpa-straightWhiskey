using PRPA.Models;

namespace PRPA.RepositoriesInterfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetReviewsForBarber(int barberId);
    }
}
