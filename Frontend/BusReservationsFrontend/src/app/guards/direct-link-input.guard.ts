import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { UserStates } from '../models/userStates';
import { PermissionsService } from '../services/permissions.service';
import { TokenStorageService } from '../services/token-storage.service';
export interface ComponentCanActivate {
  canActivate(permissions: UserStates): boolean | Observable<boolean>;
}
@Injectable({
  providedIn: 'root',
})
export class DirectLinkInputGuard implements CanActivate {
  constructor(
    private permissions: PermissionsService,
    private router: Router
  ) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    if (
      route.component?.prototype.canActivate(
        this.permissions.getPermissions(route)
      )
    )
      return true;
    this.router.navigate(['not-found']);
    return false;
  }
}
