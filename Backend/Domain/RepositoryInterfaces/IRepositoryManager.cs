using Domain.RepositoryInterfaces;
namespace Infrastructure.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IPlaygroundRepository Playground { get; }
        IBookingRepository Booking{ get; }
        IPaymentRepository Payment { get; }
        IReviewRepository Review{ get; }
        Task SaveAsync();
    }
}
