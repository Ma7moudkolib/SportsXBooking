using Application.DataTransferObjects.Booking;
using Application.DataTransferObjects.Payment;
using Application.DataTransferObjects.Playground;
using Application.DataTransferObjects.Review;
using Application.DataTransferObjects.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            // USER
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UpdateUserDto, User>();

            // PLAYGROUND
            CreateMap<Playground, GetPlaygroundDto>();
            CreateMap<CreatePlaygroundDto, Playground>();
            CreateMap<UpdatePlaygroundDto, Playground>();

            // BOOKING
            CreateMap<Booking, GetBookingDto>();
            CreateMap<CreateBooking, Booking>();
            CreateMap<Booking, GetOwnerBookingDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Player != null ? $"{src.Player.FirstName} {src.Player.LastName}" : ""))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Player != null ? src.Player.Email : ""))
                .ForMember(dest => dest.PlaygroundName, opt => opt.MapFrom(src => src.Playground != null ? src.Playground.Name : ""));

            // PAYMENT
            CreateMap<Payment, GetPaymentDto>();

            // REVIEW
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
        }
    }
}
