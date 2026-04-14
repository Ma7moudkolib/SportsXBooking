namespace Application.ServiceInterfaces
{
    public interface IServiceManager
    {
        IUserService User { get; }
        IPlaygroundService Playground { get; }
        IBookingService Booking { get; }
        IReviewService Review { get; }
        IPaymentService Payment { get; }
        IAuthenticationService Authentication { get; }

    }
}
