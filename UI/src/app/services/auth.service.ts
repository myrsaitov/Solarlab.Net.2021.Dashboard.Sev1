import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError, BehaviorSubject } from 'rxjs';
import {catchError, tap, switchMap} from 'rxjs/operators';

export interface UserRegisterDTO {
  login: string;
  email: string;
  tel: number;
  password: string;
  repeatPassword: string;
}

export interface UserLoginDTO{
  email: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _apiUrl = 'https://localhost:44377/api/v1/accounts';
  currentUser$ = new BehaviorSubject(null); // создать поток (pipeline)

  constructor(private _http: HttpClient) { }

  get token() {
    return localStorage.getItem('token'); //достать из хранилища токен
  }

  get isAuth() {           // проверка есть ли токен
    return !!this.token; // '!!'  превращает наше значение в булевское (то есть существует ли токен)
  }

  login(model: UserLoginDTO) { // идентификация с почтой и паролем
    return this._http.post(`${this._apiUrl}/login`, model).pipe(  // отправить в бек данные с почтой и паролем
      tap((res: any) => { // ловит во время запроса, перед тем как подписаться, совершает какое либо действие. обычно используется для дебага либо сделать какое то междудействие полезное ( в данном случае мы записываем наш токен в localstorage)
        if (res.token) {
          localStorage.setItem('token', JSON.stringify(res.token)); // записать токен  localstorage в формате  JSON
        }
      })
    )
  }

  logout() {
      localStorage.removeItem('token'); //удалить токен
  }

  register(model: UserRegisterDTO) { //регистрация нового пользователя
    return this._http.post(`${this._apiUrl}/register`, model); //отправить в бек данные с регистрацией
  }
}
