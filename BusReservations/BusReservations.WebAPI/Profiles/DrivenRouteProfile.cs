using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using BusReservations.WebAPI.DTOs;

namespace BusReservations.WebAPI.Profiles
{
    public class DrivenRouteProfile : Profile
    {
        public DrivenRouteProfile()
        {
            CreateMap<DrivenRoute, DrivenRouteGetDto>();
            CreateMap<TimeTable, TimeTableDto>();
            CreateMap<Seat, SeatDto>();
        }
    }
}
