
using Application.ServiceInterfaces;
using AutoMapper;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPlaygroundService> _playgroundService;
        private readonly Lazy<IBookingService> _bookingService;
        private readonly Lazy<IReviewService> _reviewService;
        private readonly Lazy<IPaymentService> _paymentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager , IMapper mapper,ILoggerManager logger ,IConfiguration configuration )
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _userService = new Lazy<IUserService>(() => new UserService(_repositoryManager, _mapper));
            _playgroundService = new Lazy<IPlaygroundService>(() => new PlaygroundService(_repositoryManager, _mapper));
            _bookingService = new Lazy<IBookingService>(() => new BookingService(_repositoryManager, _mapper));
            _reviewService = new Lazy<IReviewService>(() => new ReviewService(_repositoryManager, _mapper));
            _paymentService = new Lazy<IPaymentService>(() => new PaymentService(_repositoryManager, _mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_repositoryManager,logger, _mapper,configuration));

        }
        public IUserService User => _userService.Value;

        public IPlaygroundService Playground => _playgroundService.Value;

        public IBookingService Booking => _bookingService.Value;

        public IReviewService Review => _reviewService.Value;

        public IPaymentService Payment => _paymentService.Value;
        public IAuthenticationService Authentication => _authenticationService.Value;
    }
}
