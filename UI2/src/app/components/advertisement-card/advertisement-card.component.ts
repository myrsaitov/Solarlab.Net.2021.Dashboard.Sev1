import {Component, Input} from '@angular/core';
import {IAdvertisement} from '../../models/advertisement/i-advertisement';
import {Router} from '@angular/router';

@Component({
  selector: 'app-advertisement-card',
  templateUrl: './advertisement-card.component.html',
  styleUrls: ['./advertisement-card.component.scss']
})

export class AdvertisementCardComponent {
  @Input() advertisement: IAdvertisement;

  constructor(private readonly router: Router) {
  }

  // Отобразить объявления по заданной категории
  getContentByCategory(categoryId: number){
    this.router.navigate(['/'], { queryParams: { categoryId: categoryId } });
  }

  // Отобразить объявления по заданному тагу
  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }

  // Отобразить объявления заданного пользователя
  getContentByUserName(userName: string){
    this.router.navigate(['/'], { queryParams: { userName: userName } });
  }
}