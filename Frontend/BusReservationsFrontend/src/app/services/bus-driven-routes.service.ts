import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BusDrivenRoute } from '../models/busDrivenRoute';
@Injectable({
  providedIn: 'root',
})
export class BusDrivenRoutesService {
  constructor(private client: HttpClient) {}

  getAll(index: number = 1) {
    return this.client.get<BusDrivenRoute[]>(
      `https://localhost:7124/api/v1/bus-driven-routes?index=${index}`
    );
  }
}
