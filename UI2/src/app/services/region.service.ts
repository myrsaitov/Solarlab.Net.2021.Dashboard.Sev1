import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, takeUntil } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IRegion } from '../models/region/region-model';
import { IRegionFilter } from '../models/region/region-filter.model';
import { GetPagedRegionResponseModel } from '../models/region/get-paged-region-response-model';
import { EMPTY, Subject } from 'rxjs';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.s
})

export class RegionService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/regions/v2`;
  regions: IRegion[];
  private destroy$: Subject<boolean>;

  constructor(
    private readonly http: HttpClient) {
  }

  // Действия при инициализации
  onInit() {
    
    // Иначе ошибка ObjectUnsubscribedError
    this.destroy$ = new Subject<boolean>();

    this
      .getList({
        pageSize: 1000,
        page: 0});

  }

  // Возвращает имя региона по идентификатору
  getRegionNameById(regionId: number){
    if (typeof this.regions === 'undefined') {
      return "[region unavailable]";
    }
    else {
      return this.regions.find(s => s.id === regionId).name;
    }
  }

  // Возвращает список регионов
  getList(filter: IRegionFilter) {

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
    this.http.get<GetPagedRegionResponseModel>(`${this.ROOT_URL}`, {params})
      .pipe( // pipe - применить указанное действие ко всем элементам конвейера
        catchError((err) => {
          console.error(err);
          return EMPTY;
        }),
        takeUntil(this.destroy$)) // Поток действует, пока не придет условие destroy$)
      .subscribe(res => {
        if (res !== null) {
          this.regions = res.items
        }
      });
  }

  // Действия на закрытие
  onDestroy(): void  {
    // Устанавливает значение предиката завершения потока - "завершить поток"
    this.destroy$.next(true);
    // И отписывается от сабджекта
    this.destroy$.unsubscribe();
  }
  
}