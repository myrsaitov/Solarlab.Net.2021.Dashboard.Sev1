import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

// The @Injectable() decorator specifies that Angular can use this class in the DI system.
// providedIn: 'root', means that the Service is visible throughout the application.
@Injectable({
  providedIn: 'root' // declares that this service should be created by the root application injector.
})

export class RouterService {
  
  constructor(
    private readonly router: Router) {
  }

  // Открывает главную страницу
  goToMainPage() {
    this.router.navigate(
      ['/']
    );
  }

  // Открывает главную страницу с фильтрацией по userId
  goToLoginPage(){
    this.router.navigate(
      ['/', 'login']
    );
  }

  // Открывает страницу с объявлением
  goToAdvertisementPageById(id: number) {
    this.router.navigate(
      ['/', id]
    );
  }

  // Открывает главную страницу с фильтрацией по tag
  getAdvertisementsByTag(tag: string){
    this.router.navigate(
      ['/'],
      { queryParams: { tag: tag } }
    );
  }

  // Открывает главную страницу с фильтрацией по categoryId
  getAdvertisementsByCategoryId(categoryId: number){
    this.router.navigate(
      ['/'],
      { queryParams: { categoryId: categoryId } }
    );
  }

  // Открывает главную страницу с фильтрацией по userId
  getAdvertisementsByUserId(userId: string){
    this.router.navigate(
      ['/'],
      { queryParams: { userId: userId } }
    );
  }

  // Открывает главную страницу с фильтрацией по searchStr
  getAdvertisementsBySearchStr(searchStr: string){
    this.router.navigate(
      ['/'],
      { queryParams: { searchStr:  searchStr} }
    );
  }

}