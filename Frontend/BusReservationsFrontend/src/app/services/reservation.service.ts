import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReservationGetDto } from '../models/reservationGetDto';
import { ReservationPutPostDto } from '../models/reservationPutPostDto';

@Injectable({
  providedIn: 'root',
})
export class ReservationService {
  constructor(private client: HttpClient) {}
  addReservation(reservation: ReservationPutPostDto) {
    return this.client.post<ReservationGetDto>(
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

  getReservationById(id: string) {
    return this.client.get<ReservationGetDto>(
      `https://localhost:7124/api/v1/reservations/${id}`
    );
  }
  deleteReservation(id: string) {
    return this.client.delete(
      `https://localhost:7124/api/v1/reservations/id?id=${id}`
    );
  }
}
