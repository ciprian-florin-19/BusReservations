using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.WebAPI.DTOs;

namespace BusReservations.WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserPutPostDto, User>();
            CreateMap<Account, AccountGetDto>();
            CreateMap<AccountPutPostDto, Account>();
        }
    }
}
