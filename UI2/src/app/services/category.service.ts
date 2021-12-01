import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {ICategory} from '../models/category/category-model';
import {ICategoryFilter} from '../models/category/category-filter.model';
import {GetPagedCategoryResponseModel} from '../models/category/get-paged-category-response-model';
import {EMPTY, Observable} from 'rxjs';
import { environment } from 'src/environments/environment';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.
})

export class CategoryService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/categories`;

  constructor(
    private http: HttpClient) {
  }


  // Возвращает список категорий
  getCategoryList(filter: ICategoryFilter): Observable<ICategory[]>{

    let source = Observable.create(observer => {

      const {page, pageSize} = filter;
      if (page == null || pageSize == null) {
        return;
      }
  
      const params = new HttpParams()
      .set('page', `${page}`)
      .set('pageSize', `${pageSize}`);
 
      this.http.get<GetPagedCategoryResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe( // pipe - применить указанное действие ко всем элементам конвейера
          catchError((err) => {
            console.error(err);
            return EMPTY;
          }))
        .subscribe(category => {
          if (category !== null) {
            observer.next(category.items)
          }
        });
    })

    return source;
  }

  // Возвращает категорию по идентификатору
  getCategoryById(id: number) {
    return this.http.get<ICategory>(`${this.ROOT_URL}/${id}`)
      .pipe( // pipe - применить указанное действие ко всем элементам конвейера
        catchError((err) => {
          console.error(err);
          return EMPTY;
        }));
      
  }
}