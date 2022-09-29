import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountPutPostDto } from '../models/accountPutPostDto';
import { UserPutPostDto } from '../models/userPutPostDto';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private apiUrl: string = 'https://localhost:7124/api/v1/auth/';
  constructor(private client: HttpClient) {}

  logIn(username: string, password: string) {
    return this.client.post<{ expiration: Date; token: string }>(
      this.apiUrl + 'login',
      {
        username: username,
        password: password,
      }
    );
  }
  register(userData: AccountPutPostDto) {
    console.log();
    return this.client.post<any>(this.apiUrl + 'register', userData);
  }
}
