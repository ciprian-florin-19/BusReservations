import { Bus } from './bus';
import { BusDrivenRoute } from './busDrivenRoute';
import { DrivenRoute } from './drivenRoute';
import { Seat } from './seat';
import { User } from './user';

export interface ReservationSimpleGetDto {
  user: User;
  busDrivenRoute: BusDrivenRoute;
  seat: Seat;
  finalSeatPrice: number;
}
