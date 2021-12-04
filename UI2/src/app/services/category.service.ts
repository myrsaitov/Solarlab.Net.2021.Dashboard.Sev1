import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, takeUntil } from 'rxjs/operators';
import { ICategory } from '../models/category/category-model';
import { ICategoryFilter } from '../models/category/category-filter.model';
import { GetPagedCategoryResponseModel } from '../models/category/get-paged-category-response-model';
import { EMPTY, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.
})

export class CategoryService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/categories`;
  categories: ICategory[];
  private destroy$: Subject<boolean>;
  
  constructor(
    private readonly http: HttpClient) {
  }

  // Действия при инициализации
  onInit() {
    
    // Иначе ошибка ObjectUnsubscribedError
    this.destroy$ = new Subject<boolean>();

    this
      .getCategoryList({
        pageSize: 1000,
        page: 0});
  }

  // Возвращает имя категории по идентификатору
  getCategoryNameById(categoryId: number){
    if (typeof this.categories === 'undefined') {
      return "[categories unavailable]";
    }
    else {
      return this.categories.find(s => s.id === categoryId).name;
    }
  }

  // Возвращает список категорий
  getCategoryList(filter: ICategoryFilter){

    // Считывает значения фильтра
    const {page, pageSize} = filter;
    if (page == null || pageSize == null) {
      return;
    }
  
    // Преобразует значения фильтра в параметры HTTP-запроса
    const params = new HttpParams()
      .set('page', `${page}`)
      .set('pageSize', `${pageSize}`);
 
    // Выполняет HTTP-запрос
    this.http.get<GetPagedCategoryResponseModel>(`${this.ROOT_URL}`, {params})
      .pipe( // pipe - применить указанное действие ко всем элементам конвейера
        catchError((err) => {
          console.error(err);
          return EMPTY;
        }),
        takeUntil(this.destroy$)) // Поток действует, пока не придет условие destroy$)
      .subscribe(res => {
        if (res !== null) {
          this.categories = res.items
        }
      });
  }

  // Действия на закрытие
  onDestroy(): void  {
    this.destroy$.next(true); // Условие остановки потока
    this.destroy$.unsubscribe();
  }

}