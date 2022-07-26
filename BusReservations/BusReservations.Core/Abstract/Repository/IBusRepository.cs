﻿using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IBusRepository
    {
        void AddBus(Bus bus);
        Task<PagedList<Bus>> GetAllBuses(int pageIndex = 1);
        Task<Bus> GetBusByID(Guid busId);
        Task<IEnumerable<Bus>> GetBusesByName(string name, int pageIndex = 1);
        void UpdateBus(Bus bus);
        void DeleteBus(Bus bus);
        void AddRange(IEnumerable<Bus> buses);
    }
}
