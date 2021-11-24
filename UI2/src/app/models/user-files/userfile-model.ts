import { SafeResourceUrl } from "@angular/platform-browser";

export interface IUserFile  {
  
  // Идентификатор файла в базе
  id?: number;

  // Идентификатор файла на форме UI
  fileIdOnForm?: number;
  
  // Безопасная ссылка, см. https://angular.io/api/platform-browser/DomSanitizer#description
  tmpPreviewUri: SafeResourceUrl;
  
  // Идентификатор объявления, к которому относится этот файл
  advertisementId?: number;

  // Пользователь, который загрузил файл
  ownerId: string;

  // Массив данных файла
  content: any;

  // Массив данных файла
  contentBase64: string;
}

export class UserFile implements IUserFile {
  id?: number;
  fileIdOnForm?: number;
  tmpPreviewUri: SafeResourceUrl;
  advertisementId?: number;
  ownerId: string;
  content: any;
  contentBase64: string;
  
  constructor(data?: Partial<IUserFile>) {
    const defaults: IUserFile = {
      id: null,
      fileIdOnForm: null,
      tmpPreviewUri: '',
      advertisementId: null,
      ownerId: '',
      content: null,
      contentBase64: 'testtesttest',
      ...data
    };
    this.id = defaults.id;
    this.fileIdOnForm = defaults.fileIdOnForm;
    this.tmpPreviewUri = defaults.tmpPreviewUri;
    this.advertisementId = defaults.advertisementId;
    this.ownerId = defaults.ownerId;
    this.content = defaults.content;
    this.contentBase64 = defaults.contentBase64;
  }
}