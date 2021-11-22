import {Component, Input} from '@angular/core';
import {IAdvertisement} from '../../models/advertisement/i-advertisement';
import {Router} from '@angular/router';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-advertisement-card',
  templateUrl: './advertisement-card.component.html',
  styleUrls: ['./advertisement-card.component.scss']
})

export class AdvertisementCardComponent {
  @Input() advertisement: IAdvertisement;
  @Input() userName: string;

  constructor(private readonly router: Router) {
  }

  // Отобразить объявления по заданной категории
  getAdvertisementCategoryId(categoryId: number){
    this.router.navigate(['/'], { queryParams: { categoryId: categoryId } });
  }

  // Отобразить объявления по заданному тагу
  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }

  // Отобразить объявления заданного пользователя
  getContentByOwnerId(ownerId: string){
    this.router.navigate(['/'], { queryParams: { ownerId: ownerId } });
  }
}