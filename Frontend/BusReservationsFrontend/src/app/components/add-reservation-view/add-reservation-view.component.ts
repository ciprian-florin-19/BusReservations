import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Seat } from 'src/app/models/seat';
import { RouteDetailsService } from 'src/app/services/route-details.service';

@Component({
  selector: 'app-add-reservation-view',
  templateUrl: './add-reservation-view.component.html',
  styleUrls: ['./add-reservation-view.component.css'],
})
export class AddReservationViewComponent implements OnInit, OnDestroy {
  formData: {
    bdrId: string;
    seatNumber?: number;
  } = {
    bdrId: '',
  };
  constructor(private routeDetails: RouteDetailsService) {
    let source;
    source = JSON.parse(localStorage.getItem('routeDetails')!);
    this.formData = {
      bdrId: source.bdrId,
      seatNumber: source.selectedSeat,
    };
  }
  ngOnDestroy(): void {
    localStorage.clear();
  }

  ngOnInit(): void {}
}
