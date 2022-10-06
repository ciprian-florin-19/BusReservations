import { TimeTable } from './timeTable';

export interface DrivenRoute {
  id: string;
  start: string;
  destination: string;
  timeTable: TimeTable;
  seatPrice: number;
}
