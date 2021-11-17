import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {EMPTY, Observable} from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUserFilter } from '../models/user/user-filter.model';
import { IUser } from '../models/user/user-model';
import { GetPagedUserResponseModel } from '../models/user/get-paged-user-response-model';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.s
})

export class UserService {
  private ROOT_URL = `${environment.baseAccountsApiUrl}api/v1/accounts`;

  constructor(private http: HttpClient) {
  }

  // Возвращает список регионов
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