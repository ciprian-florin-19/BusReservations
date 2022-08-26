using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.WebAPI.DTOs;

namespace BusReservations.WebAPI.Profiles
{
    public class BusDrivenRouteProfile : Profile
    {
        public BusDrivenRouteProfile()
        {
            CreateMap<BusDrivenRoute, BusDrivenRouteGetDto>();
        }
    }
}
