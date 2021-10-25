import { Injectable } from '@angular/core';
import { AuthService} from '././services/auth.service'; 
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private _authService: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (this._authService.token) {
      request = request.clone({ // перехватывает токен и подставляет его в авторизацию
        setHeaders: {
          Authorization: `Bearer ${this._authService.token}` //Bearer - носитель. 
        }
      });
    }    
    return next.handle(request);
  
  }
}
