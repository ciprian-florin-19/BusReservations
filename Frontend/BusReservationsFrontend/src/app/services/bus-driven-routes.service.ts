import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BusDrivenRoute } from '../models/busDrivenRoute';
import { PagedList } from '../models/PagedList';
@Injectable({
  providedIn: 'root',
})
export class BusDrivenRoutesService {
  constructor(private client: HttpClient) {}

  getAll(index: number = 1) {
    return this.client.get<PagedList<BusDrivenRoute>>(
      `https://localhost:7124/api/v1/bus-driven-routes?index=${index}`
    );
  }
  getAllByDate(
    day: string | null,
    month: string | null,
    year: string | null,
    index: number = 1
  ) {
    return this.client.get<PagedList<BusDrivenRoute>>(
      `https://localhost:7124/api/v1/bus-driven-routes/filter?day=${day}&month=${month}&year=${year}&pageIndex=${index}`
    );
  }
  getAvailableRides(
    start: string | null,
    destination: string | null,
    day: string | null,
    month: string | null,
    year: string | null,
    index: number | null = 1
  ) {
    return this.client.get<PagedList<BusDrivenRoute>>(
      `https://localhost:7124/api/v1/bus-driven-routes/available?start=${start}&destination=${destination}&year=${year}&month=${month}&day=${day}&index=${index}`
    );
  }
  getBusDrivenRouteById(id: string) {
    return this.client.get<BusDrivenRoute>(
      `https://localhost:7124/api/v1/bus-driven-routes/${id}`
    );
  }
}
