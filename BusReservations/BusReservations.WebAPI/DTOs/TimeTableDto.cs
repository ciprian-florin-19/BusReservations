﻿namespace BusReservations.WebAPI.DTOs
{
    public class TimeTableGetDto
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArivvalDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
