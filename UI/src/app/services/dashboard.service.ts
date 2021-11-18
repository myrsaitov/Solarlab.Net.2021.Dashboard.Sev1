import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import { AuthService, ICardFilter, ICard} from './../services/auth.service';
import {EMPTY, Observable} from 'rxjs';

export class GetPagedCardResponseModel {
  total!: number; //количество категорий
  limit!: number;//всего  категорий
  offset!: number; // количество элементов, которое будет пропущено.( если  offset=10, будут выводиться значения, начиная с 11)
  items!: ICard[]; //категории 
}

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private ROOT_URL = `https://localhost:44378/api/v1/advertisements`; // путь по которому по получаем данные с бека
  constructor(private http: HttpClient) { //Для взаимодействия с сервером и отправки запросов
  }
  
  getCardList(filter: ICardFilter): Observable<ICard[]>{ //Фильтрует значения на основании критерия ICard
  
    let source = Observable.create((observer: { next: (arg0: ICard[]) => void; }) => { // создаем Observable с функцией ,  
  // которая мониторит состояние категорий.
      const {page, pageSize} = filter; //объявляются константы, значение которых берется из объекта filter
      if (page == null || pageSize == null) {
        return;
      }
  
      const params = new HttpParams() // помощью метода set() объекта HttpParams устанавливаются параметры
      .set('page', `${page}`)
      .set('pageSize', `${pageSize}`);
  
      this.http.get<GetPagedCardResponseModel>(`${this.ROOT_URL}`, {params}) //получить данные page, pageSize
        .pipe(catchError((err) => { //Перехватывает исключение или ошибку в потоке и возвращает новый Observable
          console.error(err); //Выводит сообщение об ошибке в веб-консоль.
          return EMPTY; //Просто издает «завершено» и больше ничего.
        }))
        .subscribe(card => { // подписаться на категорию. если категория не равно нулю - выдать значение.
          if (card !== null) {
            observer.next(card.items)
                    }
                                   
        });
    })
  return source;
  }
  
  
  getCardById(id: number) { // выдать карточку по id
  
    return this.http.get<ICard>(`${this.ROOT_URL}/${id}`) // вернуть значение (интерфейс ICard), исходя из номера id
      .pipe(catchError((err) => { //Перехватывает исключение или ошибку в потоке и возвращает новый Observable
        console.error(err); //Выводит сообщение об ошибке в веб-консоль.
        return EMPTY; //Просто издает «завершено» и больше ничего.
      }));
      
  }
  
  
  
  
  }