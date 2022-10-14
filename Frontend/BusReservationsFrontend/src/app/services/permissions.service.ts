import { Injectable } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { UserStates } from '../models/userStates';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root',
})
export class PermissionsService {
  private permissions: UserStates = {
    isLoggedIn: false,
    isAdmin: false,
    isRouteSelected: false,
    isSearchValid: false,
  };

  constructor(private tokenStorage: TokenStorageService) {}
  public getPermissions(route: ActivatedRouteSnapshot) {
    const session = this.tokenStorage.getSession();
    if (session) {
      this.permissions.isLoggedIn = true;
      if (session.roles.includes('admin')) this.permissions.isAdmin = true;
    }
    if (localStorage.getItem('routeDetails'))
      this.permissions.isRouteSelected = true;
    let queryParams = route.queryParamMap;
    let queryParamsObject = {
      start: queryParams.get('start'),
      destination: queryParams.get('destination'),
      year: queryParams.get('year'),
      month: queryParams.get('month'),
      day: queryParams.get('day'),
    };

    if (Object.values(queryParamsObject).every((el) => el != undefined))
      this.permissions.isSearchValid = true;
    return this.permissions;
  }
}
