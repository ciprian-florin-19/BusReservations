import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PagedList } from 'src/app/models/PagedList';
import { ReservationGetDto } from 'src/app/models/reservationGetDto';

@Component({
  selector: 'app-tickets-list',
  templateUrl: './tickets-list.component.html',
  styleUrls: [
    './tickets-list.component.css',
    '../bus-driven-routes-view/bus-driven-routes-view.component.css',
  ],
})
export class TicketsListComponent implements OnInit {
  @Input()
  reservations!: PagedList<ReservationGetDto>;
  @Output()
  onSendDetails: EventEmitter<ReservationGetDto> = new EventEmitter();
  @Output()
  onCancel: EventEmitter<any> = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}

  sendDetails(details: ReservationGetDto) {
    this.onSendDetails.emit(details);
  }
  cancelReservation(ticketId: string) {
    console.log('emitted');

    this.onCancel.emit(ticketId);
  }
}
