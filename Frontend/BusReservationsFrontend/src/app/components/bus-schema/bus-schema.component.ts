import { Component, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Seat } from 'src/app/models/seat';

@Component({
  selector: 'app-bus-schema',
  templateUrl: './bus-schema.component.html',
  styleUrls: ['./bus-schema.component.css'],
})
export class BusSchemaComponent implements OnInit {
  @Input()
  occupiedSeats?: Seat[] = [];
  @Input()
  capacity?: number = 0;
  @Input()
  selectedSeat?: number = -1;

  halfCapacity: number = 0;
  totalSeats: number[] = [];
  constructor() {}

  ngOnInit(): void {
    this.totalSeats = Array.from(Array(this.capacity).keys());
    if (this.capacity != undefined)
      this.halfCapacity = Math.ceil(this.capacity / 2);
  }

  isSeatOccupied(seat: number): boolean {
    if (this.occupiedSeats != undefined)
      if (this.occupiedSeats.find((s) => s.seatNumber == seat)) return true;
    return false;
  }

  selectSeat(seat: number): void {
    this.selectedSeat = seat;
    console.log(this.selectedSeat);
  }
}
