import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RouteDetails } from '../models/routeDetails';

@Injectable({
  providedIn: 'root',
})
export class RouteDetailsService {
  routeDetails = new BehaviorSubject<any>({});
  constructor() {}

  setDetails(details: any) {
    this.routeDetails.next(details);
    localStorage.setItem('routeDetails', JSON.stringify(details));
  }
}
