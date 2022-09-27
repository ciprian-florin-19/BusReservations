import { Status } from './status';

export class Seat {
  seatNumber?: number;
  status: number;
  discount?: number;
  constructor(seatNumber: number, seatType: Status) {
    this.seatNumber = seatNumber;
    this.status = seatType;
    switch (seatType) {
      case Status.student:
        this.discount = 25;
        break;
      case Status.elderly:
        this.discount = 50;
        break;
      default:
        this.discount = 0;
        break;
    }
  }
}
