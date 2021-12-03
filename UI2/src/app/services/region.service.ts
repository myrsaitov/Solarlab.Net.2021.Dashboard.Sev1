import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IRegion } from '../models/region/region-model';
import { IRegionFilter } from '../models/region/region-filter.model';
import { GetPagedRegionResponseModel } from '../models/region/get-paged-region-response-model';
import { EMPTY, Observable } from 'rxjs';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.s
})

export class RegionService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/regions/v2`;
  regions$: Observable<IRegion[]>;
  regions: IRegion[];

  constructor(
    private readonly http: HttpClient) {
          
    this.regions$ = this.getRegionList({
      pageSize: 1000,
      page: 0,
    });
    this.regions$.subscribe(regions => this.regions = regions);
  }

  // Возвращает имя региона по идентификатору
  getRegionNameById(regionId: number){
    return this.regions.find(s => s.id === regionId).name;
  }

  // Возвращает список регионов
  getRegionList(filter: IRegionFilter): Observable<IRegion[]>{

    let source = Observable.create(observer => {

      const {page, pageSize} = filter;
      if (page == null || pageSize == null) {
        return;
      }
  
      const params = new HttpParams()
      .set('page', `${page}`)
      .set('pageSize', `${pageSize}`);
 
      this.http.get<GetPagedRegionResponseModel>(`${this.ROOT_URL}`, {params})
        .pipe( // pipe - применить указанное действие ко всем элементам конвейера
          catchError((err) => {
            console.error(err);
            return EMPTY;
          }))
        .subscribe(region => {
          if (region !== null) {
            observer.next(region.items)
          }
        });
    })
  return source;
  }
}