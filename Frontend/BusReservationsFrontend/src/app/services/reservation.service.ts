import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Reservation } from '../models/reservation';

@Injectable({
  providedIn: 'root',
})
export class ReservationService {
  constructor(private client: HttpClient) {}
  addReservation(reservation: Reservation) {
    return this.client.post<Reservation>(
      `https://localhost:7124/api/v1/reservations
`,
      {
        userId: reservation.userId,
        busDrivenRouteId: reservation.busDrivenRouteId,
        seat: {
          seatNumber: reservation.seatDto.seatNumber,
          type: reservation.seatDto.status,
        },
      }
    );
  }
}
