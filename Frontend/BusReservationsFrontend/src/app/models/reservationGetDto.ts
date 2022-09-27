import { Bus } from './bus';
import { DrivenRoute } from './drivenRoute';
import { Seat } from './seat';
import { User } from './user';

export interface ReservationGetDto {
  user: User;
  drivenRoute: DrivenRoute;
  bus: Bus;
  seat: Seat;
  finalSeatPrice: number;
}
