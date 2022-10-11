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
  @Input()
  isDisabled: boolean = false;

  rowLength: number = 0;
  halfCapacity: number = 0;
  columnStyle: string = '';
  totalSeats: number[] = [];
  constructor() {}

  ngOnInit(): void {
    this.totalSeats = Array.from(Array(this.capacity).keys());
    if (this.capacity != undefined) {
      this.rowLength = Math.ceil(this.capacity / 4);
      this.halfCapacity = Math.ceil(this.capacity / 2);
      this.columnStyle = `repeat(${this.rowLength},1fr)`;
    }
  }

  isSeatOccupied(seat: number): boolean {
    if (this.occupiedSeats != undefined)
      if (this.occupiedSeats.find((s) => s.seatNumber == seat)) return true;
    return false;
  }

  selectSeat(seat: number): void {
    if (this.isDisabled) return;
    this.selectedSeat = seat;
  }
}
