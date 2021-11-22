import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { EMPTY, Observable } from 'rxjs';
import { GetPagedAdvertisementModel } from '../models/advertisement/get-paged-advertisement-model';
import { IAdvertisement } from '../models/advertisement/i-advertisement';
import { GetPagedContentResponseModel } from '../models/advertisement/get-paged-content-response-model';
import { ICreateAdvertisement } from '../models/advertisement/advertisement-create-model';
import { IEditAdvertisement } from '../models/advertisement/advertisement-edit-model';
import { environment } from 'src/environments/environment';
import { IEditAdvertisementStatus } from '../models/advertisement/advertisement-status-edit-model';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.
})

export class AdvertisementService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/advertisements`;
  private decpage: number;

  constructor(
    private http: HttpClient) {
  }

  // Возвращает список объявлений с поиском
  getAdvertisementsList(model: GetPagedAdvertisementModel): Observable<GetPagedContentResponseModel> {
    
    const {searchStr, ownerId, categoryId, tag, page, pageSize} = model;
    if (page == null || pageSize == null) {
      return;
    }

    this.decpage = 0;

    if(page > 0)
    {
      this.decpage = page - 1;
    }

    if((searchStr == null)&&(ownerId == null)&&(categoryId == null)&&(tag == null))
    {
      const params = new HttpParams()
      .set('page', `${this.decpage}`)
      .set('pageSize', `${pageSize}`);


      var ret = this.http.get<GetPagedContentResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe(
            catchError((err) => {
              console.error(err);
              return EMPTY;
            }));
      return ret;

    }
    else if((searchStr != null)&&(ownerId == null)&&(categoryId == null)&&(tag == null))
    {
      const params = new HttpParams()
      .set('searchStr', `${searchStr}`)
      .set('page', `${this.decpage}`)
      .set('pageSize', `${pageSize}`);

      var ret = this.http.get<GetPagedContentResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe(catchError((err) => {
            console.error(err);
            return EMPTY;
          }));
      return ret;
    }
    else if((searchStr == null)&&(ownerId != null)&&(categoryId == null)&&(tag == null))
    {
      const params = new HttpParams()
      .set('ownerId', `${ownerId}`)
      .set('page', `${this.decpage}`)
      .set('pageSize', `${pageSize}`);

      var ret = this.http.get<GetPagedContentResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe(catchError((err) => {
            console.error(err);
            return EMPTY;
          }));
      return ret;
    }
    else if((searchStr == null)&&(ownerId == null)&&(categoryId != null)&&(tag == null))
    {
      const params = new HttpParams()
      .set('categoryId', `${categoryId}`)
      .set('page', `${this.decpage}`)
      .set('pageSize', `${pageSize}`);

      var ret = this.http.get<GetPagedContentResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe(catchError((err) => {
            console.error(err);
            return EMPTY;
          }));
    return ret;
    }
    else if((searchStr == null)&&(ownerId == null)&&(categoryId == null)&&(tag != null))
    {
      const params = new HttpParams()
      .set('tag', `${tag}`)
      .set('page', `${this.decpage}`)
      .set('pageSize', `${pageSize}`);

      var ret = this.http.get<GetPagedContentResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe(catchError((err) => {
            console.error(err);
            return EMPTY;
          }));
      return ret;
    }
  }

  // Возвращает объявление по Id
  getAdvertisementById(id: number) {
    return this.http.get<IAdvertisement>(`${this.ROOT_URL}/${id}`)
      .pipe(catchError((err) => {
        console.error(err);
        return EMPTY;
      }));
      
  }

  // Создает новое объявление
  create(model: ICreateAdvertisement) {
    return this.http.post(`${this.ROOT_URL}`, model)
      .pipe(catchError((err) => {
        console.error(err);
        return EMPTY;
      }));
  }

  // Редактирует объявление
  edit(model: IEditAdvertisement) {
    return this.http.put(`${this.ROOT_URL}/update`, model)
      .pipe(catchError((err) => {
        console.error(err);
        return EMPTY;
      }));
  }

  // Редактирует объявление
  editStatus(model: IEditAdvertisementStatus) {
    return this.http.put(`${this.ROOT_URL}/update-status`, model)
      .pipe(catchError((err) => {
        console.error(err);
        return EMPTY;
      }));
  }

  // Удаляет объявление
  delete(id: number) {
    return this.http.delete<IAdvertisement>(`${this.ROOT_URL}/${id}`)
      .pipe(catchError((err) => {
        console.error(err);
        return EMPTY;
      }));
  }
}