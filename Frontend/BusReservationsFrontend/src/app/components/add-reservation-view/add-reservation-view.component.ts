import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ComponentCanActivate } from 'src/app/guards/direct-link-input.guard';
import { Seat } from 'src/app/models/seat';
import { UserStates } from 'src/app/models/userStates';
import { RouteDetailsService } from 'src/app/services/route-details.service';

@Component({
  selector: 'app-add-reservation-view',
  templateUrl: './add-reservation-view.component.html',
  styleUrls: ['./add-reservation-view.component.css'],
})
export class AddReservationViewComponent
  implements OnInit, OnDestroy, ComponentCanActivate
{
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
  canActivate(permissions: UserStates): boolean | Observable<boolean> {
    console.log(permissions);

    if (permissions.isRouteSelected) return true;
    return false;
  }
  ngOnDestroy(): void {
    localStorage.clear();
  }

  ngOnInit(): void {}
}
