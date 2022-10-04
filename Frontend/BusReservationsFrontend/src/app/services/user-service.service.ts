import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { PagedList } from '../models/PagedList';
import { ReservationGetDto } from '../models/reservationGetDto';

@Injectable({
  providedIn: 'root',
})
export class UserServiceService {
  constructor(private client: HttpClient) {}

  getExistingUser(user: User) {
    return this.client
      .get<User>(`https://localhost:7124/api/v1/users/existing?name=${user.fullName}&phone=${user.phoneNumber}&email=${user.email}
`);
  }
  getUserById(id: string) {
    return this.client.get<User>(`https://localhost:7124/api/v1/users/${id}
`);
  }
  addUser(user: User) {
    return this.client.post<User>(
      `https://localhost:7124/api/v1/users
`,
      {
        fullName: user.fullName,
        phoneNumber: user.phoneNumber,
        email: user.email,
        status: 0,
      }
    );
  }
  getUserReservations(userId: string, index: number = 1) {
    return this.client.get<
      PagedList<ReservationGetDto>
    >(`https://localhost:7124/api/v1/users/${userId}/reservations?index=${index}
`);
  }
}
