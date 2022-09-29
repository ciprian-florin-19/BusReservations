import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../models/account';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private client: HttpClient) {}

  getAccountById(id: string) {
    return this.client.get<Account>(
      `https://localhost:7124/api/v1/accounts/${id}`
    );
  }
}
