import { TimeTable } from './timeTable';

export interface DrivenRoute {
  start: string;
  destination: string;
  timeTable: TimeTable;
  seatPrice: number;
}
