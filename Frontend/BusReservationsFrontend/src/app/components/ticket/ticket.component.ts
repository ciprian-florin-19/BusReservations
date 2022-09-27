import { Component, Input, OnInit } from '@angular/core';
import { BusDrivenRoute } from 'src/app/models/busDrivenRoute';
import { ReservationGetDto } from 'src/app/models/reservationGetDto';
import { Seat } from 'src/app/models/seat';
import { Status } from 'src/app/models/status';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css'],
})
export class TicketComponent implements OnInit {
  @Input()
  reservation?: ReservationGetDto;
  constructor() {}

  ngOnInit(): void {
    console.log(this.reservation);
  }
  getStatusName(status: number): string {
    switch (status) {
      case 0:
        return 'ADULT';
      case 1:
        return 'ELEV/STUDENT';
      case 2:
        return 'PENSIONAR';
      default:
        return 'ADULT';
    }
  }
}
