import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import * as moment from 'moment';
import { utc } from 'moment';
import { BehaviorSubject } from 'rxjs';
import { Session } from '../models/session';

const SESSION_KEY = 'session';
const TOKEN_KEY = 'token';

@Injectable({
  providedIn: 'root',
})
export class TokenStorageService {
  token: string = '';
  exists: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(
    this.isTokenValid()
  );
  constructor() {}

  getSession(): Session {
    return JSON.parse(window.sessionStorage.getItem(SESSION_KEY)!);
  }
  getToken(): string {
    return window.sessionStorage.getItem(TOKEN_KEY)!;
  }
  private isTokenValid() {
    const token = this.getToken();
    const session = this.getSession();
    if (token && session && new Date(session.exp * 1000) > new Date()) {
      return true;
    }
    return false;
  }
  saveSession() {
    const helper = new JwtHelperService();
    const decodedToken = helper.decodeToken(this.token);
    const session = this.toSession(decodedToken);
    window.sessionStorage.setItem(TOKEN_KEY, this.token);
    window.sessionStorage.setItem(SESSION_KEY, JSON.stringify(session));
    this.exists.next(true);
  }
  clearSession() {
    window.sessionStorage.clear();
    this.exists.next(false);
  }
  private toSession(decodedToken: any) {
    let session: Session = {
      accountId: ' ',
      exp: Date.now(),
      roles: [],
    };
    console.log(decodedToken);

    for (let prop in decodedToken) {
      console.log(prop);
      if (prop.includes('role')) session.roles.push(decodedToken[prop]);
      if (prop.includes('userdata')) session.accountId = decodedToken[prop];
      if (prop.includes('exp')) session.exp = decodedToken[prop];
      console.log(decodedToken[prop]);
      console.log(session.exp);
    }
    return session;
  }
}
