import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import { AuthService, ICategory, ICategoryFilter} from './../services/auth.service';
import {EMPTY, Observable} from 'rxjs';

export class GetPagedCategoryResponseModel {
  total!: number; //количество категорий
  limit!: number;//всего  категорий
  offset!: number; // количество элементов, которое будет пропущено.( если  offset=10, будут выводиться значения, начиная с 11)
  items!: ICategory[]; //категории 
}

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private ROOT_URL = `https://localhost:44378/api/v1/categories`; // путь по которому по получаем данные с бека
  constructor(private http: HttpClient) { //Для взаимодействия с сервером и отправки запросов
}

getCategoryList(filter: ICategoryFilter): Observable<ICategory[]>{ //Фильтрует значения на основании критерия ICategoryFilter

  let source = Observable.create((observer: { next: (arg0: ICategory[]) => void; }) => { // создаем Observable с функцией , который observer, 
// которая мониторит состояние категорий.
    const {page, pageSize} = filter; //объявляются константы, значение которых берется из объекта filter
    if (page == null || pageSize == null) {
      return;
    }

    const params = new HttpParams() // помощью метода set() объекта HttpParams устанавливаются параметры
    .set('page', `${page}`)
    .set('pageSize', `${pageSize}`);

    this.http.get<GetPagedCategoryResponseModel>(`${this.ROOT_URL}`, {params}) //получить данные page, pageSize
      .pipe(catchError((err) => { //Перехватывает исключение или ошибку в потоке и возвращает новый Observable
        console.error(err); //Выводит сообщение об ошибке в веб-консоль.
        return EMPTY; //Просто издает «завершено» и больше ничего.
      }))
      .subscribe(category => { // подписаться на категорию. если категория не равно нулю - выдать значение.
        if (category !== null) {
          observer.next(category.items)
      }
      });
  })
return source;
}


getCategoryById(id: number) { // выдать категорию по id

  return this.http.get<ICategory>(`${this.ROOT_URL}/${id}`) // вернуть значение (интерфейс ICategory), исходя из номера id
    .pipe(catchError((err) => { //Перехватывает исключение или ошибку в потоке и возвращает новый Observable
      console.error(err); //Выводит сообщение об ошибке в веб-консоль.
      return EMPTY; //Просто издает «завершено» и больше ничего.
    }));
    
}
}