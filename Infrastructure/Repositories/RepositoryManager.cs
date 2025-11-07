using Domain.RepositoryInterfaces;
using Infrastructure.DatabaseContext;

namespace Infrastructure.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IPlaygroundRepository> _playgroundRepository;
        private readonly Lazy<IBookingRepository> _bookingRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IReviewRepository> _reviewRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_repositoryContext));
            _playgroundRepository = new Lazy<IPlaygroundRepository>(() => new PlaygroundRepository(_repositoryContext));
            _bookingRepository = new Lazy<IBookingRepository>(() => new BookingRepository(_repositoryContext));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(_repositoryContext));
            _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(_repositoryContext));
        }
        public IUserRepository User => _userRepository.Value;

        public IPlaygroundRepository Playground => _playgroundRepository.Value;

        public IBookingRepository Booking => _bookingRepository.Value;

        public IPaymentRepository Payment => _paymentRepository.Value;

        public IReviewRepository Review => _reviewRepository.Value;

        public Task SaveAsync()=> _repositoryContext.SaveChangesAsync();
    }
}
