import { Bus } from './bus';
import { DrivenRoute } from './drivenRoute';
import { Seat } from './seat';

export interface BusDrivenRoute {
  bus?: Bus;
  drivenRoute?: DrivenRoute;
  occupiedSeats?: Seat[];
}
