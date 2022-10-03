import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../models/account';
import { AccountPutPostDto } from '../models/accountPutPostDto';

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
  updateAccount(id: string, accountDto: AccountPutPostDto) {
    return this.client.put(
      `https://localhost:7124/api/v1/accounts/${id}`,
      accountDto
    );
  }
}
