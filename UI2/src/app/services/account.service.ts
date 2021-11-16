import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IRegister} from '../models/account/register.model';
import {catchError} from 'rxjs/operators';
import {EMPTY} from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  private ROOT_URL = `${environment.baseAccountsApiUrl}api/v1/accounts`;
  constructor(private http: HttpClient) { }

  register(model: IRegister) {
    return this.http.post(`${this.ROOT_URL}/register`, model).pipe(catchError((error) => {
      console.error(error);
      return EMPTY;
    }));
  }
}