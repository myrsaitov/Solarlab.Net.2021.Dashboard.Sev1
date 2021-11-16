import {Injectable} from '@angular/core';
import {BehaviorSubject} from 'rxjs';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.
})

export class AuthService {
  private readonly tokenName = '  login_session';
  private isAuthSubject$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  get isAuth() {
    return this.isAuthSubject$.value;
  }

  get isAuth$() {
    return this.isAuthSubject$.asObservable();
  }

  // Загружает сессию
  loadSession(): void {
    this.isAuthSubject$.next(!!this.getSession());
  }

  // Сохраняет данные о сессии в хранилище
  saveSession(token: string): void {
    localStorage.setItem(this.tokenName, JSON.parse(token).token);
    this.isAuthSubject$.next(!!this.getSession());
  }

  // Возвращает данные о сессии их хранилища
  getSession(): string {
    return localStorage.getItem(this.tokenName);
  }

  // Удаляет данные о сессии их хранилища
  deleteSession(): void {
    localStorage.removeItem(this.tokenName);
    this.isAuthSubject$.next(!!this.getSession());
  }

  getUserName() {

    return localStorage.getItem('currentUser');

  }

  isAuthenticated(): Promise<boolean> {
    return new Promise((resolve) => {
      resolve(!!this.getSession());
    });
  }
}
