import { Seat } from './seat';

export interface Reservation {
  userId: string;
  busDrivenRouteId: string;
  seatDto: Seat;
}
