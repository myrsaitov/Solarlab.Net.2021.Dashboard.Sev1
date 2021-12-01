import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {EMPTY, Observable} from 'rxjs';
import { environment } from 'src/environments/environment';
import { GetPagedTagResponseModel } from '../models/tag/get-paged-tag-response-model';
import { ITag } from '../models/tag/tag-model';
import { ITagFilter } from '../models/tag/tag-filter.model';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.s
})

export class TagService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/tags`;

  constructor(
    private readonly http: HttpClient) {
  }

  // Возвращает список тагов
  getTagList(filter: ITagFilter): Observable<ITag[]>{

    let source = Observable.create(observer => {

      const {page, pageSize} = filter;
      if (page == null || pageSize == null) {
        return;
      }
  
      const params = new HttpParams()
      .set('page', `${page}`)
      .set('pageSize', `${pageSize}`);
 
      this.http.get<GetPagedTagResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe( // pipe - применить указанное действие ко всем элементам конвейера
          catchError((err) => {
            console.error(err);
            return EMPTY;
          }))
        .subscribe(tag => {
          if (tag !== null) {
            observer.next(tag.items)
            console.log(tag)
          }
        });
    })
  return source;
  }
}