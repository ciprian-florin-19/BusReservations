import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SearchOptionsService {
  //TO DO get available routes using api call
  //TO DO extract data into properties
  private availableRoutes: any;
  startOptions: string[] = [
    'Sibiu',
    'Pitesti',
    'Bucuresti',
    'Timisoara',
    'Cluj',
    'Brasov',
  ];
  destinationOptions: string[] = ['Sibiu', 'Pitesti', 'Bucuresti'];
  constructor() {}
  getSearchOptions() {
    return {
      start: this.startOptions,
      destination: this.destinationOptions,
    };
  }
}
