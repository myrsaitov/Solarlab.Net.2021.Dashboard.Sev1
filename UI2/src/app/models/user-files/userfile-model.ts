import { SafeResourceUrl } from "@angular/platform-browser";

export interface IUserFile  {
  
  // Идентификатор файла в базе
  id?: number;

  // Индекс файла в массиве на UI
  index?: number;
  
  // Безопасная ссылка, см. https://angular.io/api/platform-browser/DomSanitizer#description
  uri: SafeResourceUrl;
  
  // Идентификатор объявления, к которому относится этот файл
  advertisementId?: number;

  // Пользователь, который загрузил файл
  ownerId: string;

  // Массив данных файла
  content: any;
}