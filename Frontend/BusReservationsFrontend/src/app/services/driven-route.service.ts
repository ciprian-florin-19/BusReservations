import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DrivenRoute } from '../models/drivenRoute';
import { PagedList } from '../models/PagedList';

@Injectable({
  providedIn: 'root',
})
export class DrivenRouteService {
  constructor(private client: HttpClient) {}

  getRouteById(id: string) {
    return this.client
      .get<DrivenRoute>(`https://localhost:7124/api/v1/driven-routes/${id}
`);
  }
  getDrivenRoutes(index: number = 1) {
    return this.client.get<
      PagedList<DrivenRoute>
    >(`https://localhost:7124/api/v1/driven-routes?index=${index}
`);
  }
  updateDrivenRoute(id: string, route: DrivenRoute) {
    return this.client.put(
      `https://localhost:7124/api/v1/driven-routes/${id}`,
      {
        start: route.start,
        destination: route.destination,
        timeTable: {
          departureDate: route.timeTable.departureDate,
          arivvalDate: route.timeTable.arivvalDate,
        },
        seatPrice: route.seatPrice,
      }
    );
  }
  addDrivenRoute(id: string, route: DrivenRoute) {
    return this.client.post<DrivenRoute>(
      `https://localhost:7124/api/v1/driven-routes/${id}`,
      {
        start: route.start,
        destination: route.destination,
        timeTable: {
          departureDate: route.timeTable.departureDate,
          arivvalDate: route.timeTable.arivvalDate,
        },
        seatPrice: route.seatPrice,
      }
    );
  }
  deleteDrivenRoute(id: string) {
    return this.client.delete(`https://localhost:7124/api/v1/driven-routes/${id}
`);
  }
}
