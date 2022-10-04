import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RouteDetails } from '../models/routeDetails';

@Injectable({
  providedIn: 'root',
})
export class RouteDetailsService {
  constructor() {}

  setDetails(details: any) {
    localStorage.setItem('routeDetails', JSON.stringify(details));
  }
}
