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

            // PAYMENT
            CreateMap<Payment, GetPaymentDto>();

            // REVIEW
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
        }
    }
}
