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
            CreateMap<DrivenRoute, DrivenRouteGetDto>()
                .ForMember(dr => dr.Buses,
                b => b.MapFrom(dr => dr.BusDrivenRoutes
                .Select(bdr => bdr.Bus)));
            CreateMap<DrivenRoutePutPostDto, DrivenRoute>();
            CreateMap<DrivenRoute, DrivenRouteSimpleDto>();
            CreateMap<TimeTable, TimeTableGetDto>();
            CreateMap<TimeTablePutPostDto, TimeTable>();
        }
    }
}
