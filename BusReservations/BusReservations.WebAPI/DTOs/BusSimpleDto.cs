﻿namespace BusReservations.WebAPI.DTOs
{
    public class BusSimpleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
