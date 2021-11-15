import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {EMPTY} from 'rxjs';
import {GetPagedRegionModel} from '../models/region/get-paged-region-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  private ROOT_URL = `${environment.baseAdvertisementsApiUrl}api/v1/regions`;

  constructor(private http: HttpClient) {
  }

  getRegions()
  {
    const params = new HttpParams()
      .set('page', `0`)
      .set('pageSize', `1000`);

    return this.http.get<GetPagedRegionModel>(`${this.ROOT_URL}`, {params})
    .pipe(catchError((err) => 
    {
      console.error(err);
      return EMPTY;
    }));
  }
}