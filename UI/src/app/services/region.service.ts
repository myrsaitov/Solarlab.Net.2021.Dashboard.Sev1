import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import { AuthService, IRegionFilter, IRegion} from './../services/auth.service';
import {EMPTY, Observable} from 'rxjs';

export class GetPagedRegionResponseModel {
  total!: number; //количество категорий
  limit!: number;//всего  категорий
  offset!: number; // количество элементов, которое будет пропущено.( если  offset=10, будут выводиться значения, начиная с 11)
  items!: IRegion[]; //категории 
}



@Injectable({
  providedIn: 'root'
})
export class RegionService {
  private ROOT_URL = `https://localhost:44378/api/v1/regions`; // путь по которому по получаем данные с бека
  constructor(private http: HttpClient) { //Для взаимодействия с сервером и отправки запросов
  }
  getRegionList(filter: IRegionFilter): Observable<IRegion[]>{ //Фильтрует значения на основании критерия IRegion
  
    let source = Observable.create((observer: { next: (arg0: IRegion[]) => void; }) => { // создаем Observable с функцией ,  
  // которая мониторит состояние категорий.
      const {page, pageSize} = filter; //объявляются константы, значение которых берется из объекта filter
      if (page == null || pageSize == null) {
        return;
      }
  
      const params = new HttpParams() // помощью метода set() объекта HttpParams устанавливаются параметры
      .set('page', `${page}`)
      .set('pageSize', `${pageSize}`);
  
      this.http.get<GetPagedRegionResponseModel>(`${this.ROOT_URL}`, {params}) //получить данные page, pageSize
        .pipe(catchError((err) => { //Перехватывает исключение или ошибку в потоке и возвращает новый Observable
          console.error(err); //Выводит сообщение об ошибке в веб-консоль.
          return EMPTY; //Просто издает «завершено» и больше ничего.
        }))
        .subscribe(region => { // подписаться на категорию. если категория не равно нулю - выдать значение.
          if (region !== null) {
            observer.next(region.items)
                    }
                                   
        });
    })
  return source;
  }
  
  
  getRegionById(id: number) { // выдать карточку по id
  
    return this.http.get<IRegion>(`${this.ROOT_URL}/${id}`) // вернуть значение (интерфейс IRegion), исходя из номера id
      .pipe(catchError((err) => { //Перехватывает исключение или ошибку в потоке и возвращает новый Observable
        console.error(err); //Выводит сообщение об ошибке в веб-консоль.
        return EMPTY; //Просто издает «завершено» и больше ничего.
      }));
      
  }
  
}
