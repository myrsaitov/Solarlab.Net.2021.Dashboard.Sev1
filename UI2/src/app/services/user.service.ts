import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError,  switchMap } from 'rxjs/operators';
import {EMPTY, Observable, of} from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUser } from '../models/user/user-model';
import { ILogin } from '../models/account/login.model';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.s
})

export class UserService {
  private ROOT_URL = `${environment.baseAccountsApiUrl}api/v1/accounts`;
  user: IUser;

  constructor(
    private readonly http: HttpClient,
    private readonly auth: AuthService,
    private readonly router: Router) {
  }

  // Возвращает пользователя по идентификатору
  getUserById(userId: string){
    this.http
      .get<IUser>(`${this.ROOT_URL}/user/${userId}`)
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        }))
      .subscribe(
        user => this.user = user
      );
  }

  // Авторизация пользователя
  login(formData: ILogin): Observable<boolean> {
    return this.http.put(
      `${this.ROOT_URL}/login`,
      formData)
      .pipe(
        switchMap((res: any) => {
          // Сохраняет сессию
          this.auth.saveSession(res);
          // Открывает главную страницу
          this.router.navigate(['/']);
          // Возвращаем NotLoginedStatus = false
          return of(false);
        }),
        catchError(() => {
          // Возвращаем NotLoginedStatus = true 
          return of(true);
        })
      );
  }
}