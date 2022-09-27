import { Seat } from './seat';

export interface ReservationPutPostDto {
  id: string;
  userId: string;
  busDrivenRouteId: string;
  seatDto: Seat;
}
