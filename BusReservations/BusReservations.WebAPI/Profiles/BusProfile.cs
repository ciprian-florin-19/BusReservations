using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using BusReservations.WebAPI.DTOs;

namespace BusReservations.WebAPI.Profiles
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<Bus, BusGetDto>()
                .ForMember(b => b.DrivenRoutes,
                b => b.MapFrom(x => x.BusDrivenRoutes
                .Select(b => b.DrivenRoute)));
            CreateMap<BusPutPostDto, Bus>();
            CreateMap<Bus, BusPutPostDto>();
            CreateMap<Bus, BusSimpleDto>();
        }
    }
}
