import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {EMPTY, Observable} from 'rxjs';
import { environment } from 'src/environments/environment';
import { IRegion } from '../models/region/region-model';
import { IRegionFilter } from '../models/region/region-filter.model';
import { GetPagedRegionResponseModel } from '../models/region/get-paged-region-response-model';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/regions/v2`;

  constructor(private http: HttpClient) {
  }


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
        .pipe(catchError((err) => {
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

  getRegionById(id: number) {

    return this.http.get<IRegion>(`${this.ROOT_URL}/${id}`)
      .pipe(catchError((err) => {
        console.error(err);
        return EMPTY;
      }));
      
  }





}
