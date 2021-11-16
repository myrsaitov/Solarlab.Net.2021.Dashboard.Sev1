import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {EMPTY} from 'rxjs';
import {GetPagedTagModel} from '../models/tag/get-paged-tag-model';
import { environment } from 'src/environments/environment';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.
})

export class TagService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/tags`;

  constructor(private http: HttpClient) {
  }

  getTags()
  {
    const params = new HttpParams()
      .set('page', `0`)
      .set('pageSize', `1000`);

    return this.http.get<GetPagedTagModel>(`${this.ROOT_URL}`, {params})
    .pipe( // pipe - применить указанное действие ко всем элементам конвейера
      catchError((err) => {
        console.error(err);
        return EMPTY;
      }));
  }
}