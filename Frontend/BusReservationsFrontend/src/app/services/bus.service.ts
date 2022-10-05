import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bus } from '../models/bus';
import { PagedList } from '../models/PagedList';

@Injectable({
  providedIn: 'root',
})
export class BusService {
  constructor(private client: HttpClient) {}

  getAllBuses(index: number = 1) {
    return this.client.get<PagedList<Bus>>(
      `https://localhost:7124/api/v1/buses?index=${index}`
    );
  }
  deleteBus(id: string) {
    return this.client.delete(`https://localhost:7124/api/v1/buses/${id}`);
  }
  getBusById(id: string) {
    return this.client.get<Bus>(`https://localhost:7124/api/v1/buses/${id}`);
  }
  updateBus(id: string, bus: Bus) {
    return this.client.put(`https://localhost:7124/api/v1/buses/${id}`, {
      name: bus.name,
      capacity: bus.capacity,
    });
  }
  addBus(id: string, bus: Bus) {
    return this.client.post<Bus>(`https://localhost:7124/api/v1/buses/${id}`, {
      name: bus.name,
      capacity: bus.capacity,
    });
  }
}
