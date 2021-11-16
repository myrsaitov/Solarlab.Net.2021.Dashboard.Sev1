import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
@Injectable()

export class AuthHeadersInterceptor implements HttpInterceptor {

  constructor(
    private readonly authService: AuthService
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const httpRequest = req.clone({
      setHeaders: {
        'Authorization': `bearer ${this.authService.getSession()}`
      }
    });
    console.log(httpRequest.body);
    return next.handle(httpRequest);
  }
}
