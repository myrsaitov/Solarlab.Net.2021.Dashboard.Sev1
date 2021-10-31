import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError, BehaviorSubject } from 'rxjs';
import {catchError, tap, switchMap} from 'rxjs/operators';

export interface IUserRegisterDTO {
  login: string;
  email: string;
  tel: string;
  password: string;
  repeatPassword: string;
}

export interface IUserLoginDTO{
  email: string;
  password: string;
}




export interface IАnnouncementDTO{ 
  title: string; //title
  price: number; //price
  body: string; //body
  address: string; //
  categoryId: string; //
  tagBodies: [];
}


export interface ICategory {
  id: number;
  name: string;
  parentCategory: ICategory; 
  }
export interface ICategoryFilter {
  page: number;
  pageSize: number;
}


export interface Tag {
  name: string;
}


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _apiUrl = 'https://localhost:44377/api/v1';
  private _apiUrlAdvertisements = 'https://localhost:44378/api/v1';
  currentUser$ = new BehaviorSubject(null); // создать поток (pipeline)

  constructor(private _http: HttpClient) { }

  get token() {
    return localStorage.getItem('token'); //достать из хранилища токен
  }

  get isAuth() {           // проверка есть ли токен
    return !!this.token; // '!!'  превращает наше значение в булевское (то есть существует ли токен)
  }

  login(model: IUserLoginDTO) { // идентификация с почтой и паролем
    

    
    return this._http.post(`${this._apiUrl}/accounts/login`, model).pipe(  // отправить в бек данные с почтой и паролем
      tap((res: any) => { // ловит во время запроса, перед тем как подписаться, совершает какое либо действие. обычно используется для дебага либо сделать какое то междудействие полезное ( в данном случае мы записываем наш токен в localstorage)

        if (res.token) {
        
          localStorage.setItem('token', res.token); // записать токен  localstorage
        }
      })
    )
  }

  logout() {
      localStorage.removeItem('token'); //удалить токен
  }

  register(model: IUserRegisterDTO) { //регистрация нового пользователя
    return this._http.post(`${this._apiUrl}/accounts/register`, model); //отправить в бек данные с регистрацией
  }
///*
  create(model: IАnnouncementDTO) { //добавление нового объявления
    return this._http.post(`${this._apiUrlAdvertisements}/advertisements`, model); //отправить в бек данные с обьявлением
  }




}
