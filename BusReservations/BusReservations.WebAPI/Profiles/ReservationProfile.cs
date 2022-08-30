using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using BusReservations.WebAPI.DTOs;

namespace BusReservations.WebAPI.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationGetDto>()
                .ForMember(r => r.DrivenRoute,
                dr => dr.MapFrom(bdr => bdr.BusDrivenRoute.DrivenRoute))
                .ForMember(r => r.Bus,
                dr => dr.MapFrom(bdr => bdr.BusDrivenRoute.Bus));
            CreateMap<ReservationPutPostDto, Reservation>();
            CreateMap<Reservation, ReservationSimpleGetDto>();
        }
    }
}
