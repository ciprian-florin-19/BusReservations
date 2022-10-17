import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ComponentCanActivate } from 'src/app/guards/direct-link-input.guard';
import { UserStates } from 'src/app/models/userStates';

@Component({
  selector: 'app-booking-complete-view',
  templateUrl: './booking-complete-view.component.html',
  styleUrls: ['./booking-complete-view.component.css'],
})
export class BookingCompleteViewComponent
  implements OnInit, ComponentCanActivate
{
  constructor() {}
  canActivate(permissions: UserStates): boolean | Observable<boolean> {
    return true;
  }

  ngOnInit(): void {}
}
