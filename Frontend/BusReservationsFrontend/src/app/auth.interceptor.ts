import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenStorageService } from './services/token-storage.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private tokenStorage: TokenStorageService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    if (this.tokenStorage.exists.value) {
      const cloned = request.clone({
        headers: request.headers.set(
          'Authorization',
          'Bearer ' + this.tokenStorage.getToken()
        ),
      });
      return next.handle(cloned);
    }
    return next.handle(request);
  }
}
