import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PagedList } from 'src/app/models/PagedList';
import { ReservationSimpleGetDto } from 'src/app/models/reservationSimpleGetDto';

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
  reservations!: PagedList<ReservationSimpleGetDto>;
  @Output()
  sendDetailsEvent: EventEmitter<ReservationSimpleGetDto> = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}

  sendDetails(details: ReservationSimpleGetDto) {
    this.sendDetailsEvent.emit(details);
  }
}
