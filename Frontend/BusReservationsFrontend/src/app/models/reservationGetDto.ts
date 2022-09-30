import { Bus } from './bus';
import { BusDrivenRoute } from './busDrivenRoute';
import { DrivenRoute } from './drivenRoute';
import { Seat } from './seat';
import { User } from './user';

export interface ReservationGetDto {
  user: User;
  drivenRoute: BusDrivenRoute;
  seat: Seat;
  finalSeatPrice: number;
}
