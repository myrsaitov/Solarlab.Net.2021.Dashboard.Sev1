import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError, map, switchMap} from 'rxjs/operators';
import {EMPTY, Observable, of, Subject} from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUserFilter } from '../models/user/user-filter.model';
import { IUser } from '../models/user/user-model';
import { GetPagedUserResponseModel } from '../models/user/get-paged-user-response-model';
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
  users$: Observable<IUser[]>;
  users: IUser[];

  constructor(
    private readonly http: HttpClient,
    private readonly auth: AuthService,
    private readonly router: Router) {
  }

  userInit() {
    this.users$ = this.getUserList({
      pageSize: 1000,
      page: 0,
    });
    //return this.users$;
    this.users$.subscribe(users => {
      this.users = users;
    });
  }

  // Возвращает пользователя по идентификатору
 /* getUserById(userId: string): Observable<IUser>{
    return this.http.get<IUser>(`${this.ROOT_URL}/user/${userId}`)
      .pipe(
        catchError((err) => {
          console.error(err);
          return EMPTY;
        }));
  }*/

  // Возвращает имя пользователя по идентификатору
  getUserNameById(userId: string){
    return this.users.find(s => s.userId === userId).userName;
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
        }));
  }

  // Возвращает список пользователей
  getUserList(filter: IUserFilter): Observable<IUser[]>{

    let source = Observable.create(observer => {

      const {page, pageSize} = filter;
      if (page == null || pageSize == null) {
        return;
      }
  
      const params = new HttpParams()
      .set('page', `${page}`)
      .set('pageSize', `${pageSize}`);
 
      this.http.get<GetPagedUserResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe( // pipe - применить указанное действие ко всем элементам конвейера
          catchError((err) => {
            console.error(err);
            return EMPTY;
          }))
        .subscribe(user => {
          if (user !== null) {
            observer.next(user.items)
            console.log(user)
          }
        });
    })
  return source;
  }

}