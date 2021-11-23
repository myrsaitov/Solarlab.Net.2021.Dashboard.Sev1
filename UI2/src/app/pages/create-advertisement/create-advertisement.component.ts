import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AdvertisementService} from '../../services/advertisement.service';
import {CreateAdvertisement, ICreateAdvertisement} from '../../models/advertisement/advertisement-create-model';
import {take} from 'rxjs/operators';
import {Router} from '@angular/router';
import {ToastService} from '../../services/toast.service';
import {CategoryService} from '../../services/category.service';
import {Observable} from 'rxjs';
import {ICategory} from '../../models/category/category-model';
import { TagService } from '../../services/tag.service';
import { RegionService } from 'src/app/services/region.service';
import { IRegion } from 'src/app/models/region/region-model';
import { AuthService } from 'src/app/services/auth.service';
import { ITag } from 'src/app/models/tag/tag-model';
import { DomSanitizer } from '@angular/platform-browser';
import { IThumbnailImage, ThumbnailImage } from 'src/app/models/thumbnail-image/thumbnail-image-model';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-create-advertisement',
  templateUrl: './create-advertisement.component.html',
  styleUrls: ['./create-advertisement.component.scss']
})
export class CreateAdvertisementComponent implements OnInit {
  form: FormGroup;
  categories$: Observable<ICategory[]>;
  regions$: Observable<IRegion[]>;
  tags$: Observable<ITag[]>;
  uri: string;
  formData: FormData = new FormData();
  thumbnailImages: IThumbnailImage[] = [];
  @ViewChild('fileInput')
  myInputVariable: ElementRef;
  fileId: number = 0; // уникальный id файла, который загружается на форму

  constructor(private fb: FormBuilder,
              private advertisementService: AdvertisementService,
              private categoryService: CategoryService,
              private router: Router,
              private toastService: ToastService,
              private tagService: TagService,
              private regionService: RegionService,
              private authService: AuthService,
              private sanitizer: DomSanitizer) {
  }

  ngOnInit() {
    
    // Подписка на категории
    this.categories$ = this.categoryService.getCategoryList({
      pageSize: 1000,
      page: 0,
    });

    // Подписка на регионы
    this.regions$ = this.regionService.getRegionList({
      pageSize: 1000,
      page: 0,
    });

    // Подписка на таги
    this.tags$ = this.tagService.getTagList({
      pageSize: 1000,
      page: 0,
    });

    // Валидаторы
    this.form = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(100)]],
      body: ['', [Validators.required, Validators.maxLength(1000)]],
      price: ['', [Validators.pattern("[0-9,]*"), Validators.maxLength(10)]],
      categoryId: [null, Validators.required],
      regionId: [localStorage.getItem('regionId'), [Validators.required]],
      address: ['', [Validators.maxLength(100)]],
      input_tags: ['', [Validators.maxLength(50)]],
      status: [0, [Validators.required]],
    });
  }

  // Возвращает значение c формы соответсвующего поля
  get title() { return this.form.get('title'); }
  get body() { return this.form.get('body'); }
  get price() { return this.form.get('price'); }
  get categoryId() { return this.form.get('categoryId'); }
  get regionId() { return this.form.get('regionId'); }
  get address() { return this.form.get('address'); }
  get input_tags() { return this.form.get('input_tags'); }
  get status() { return this.form.get('status'); }

  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }
  
  // Отобразить объявления по заданной категории
  getAdvertisementCategoryId(categoryId: number){
    this.router.navigate(['/'], { queryParams: { categoryId: categoryId } });
  }

  // Удаление файла
  onFileDeleteFromForm(id) {
    // Удаляет элемент из массива картинок с индексом id.
    // Тут надо заметить, что индекс элемента в массиве 
    // может меняться (т.к. добавляются или удаляются элементы),
    // а индекс файла уникален. В связи с чем, сначала нужно найти 
    // элемент, у которого индекс равен id, вычислить его индекс и только потом удалять
    this.thumbnailImages.forEach((element,index) => { //index - это индекс элемента в массиве
      if(element.id==id) {
        this.thumbnailImages.splice(index,1);
      }
    });
  }

  // Обработка загрузки файлов с формы https://blog.angular-university.io/angular-file-upload/
  onFileSelected(event) {

    // Если были ранее выбранные файлы, то удаляем
    //this.formData = new FormData();
    //this.thumbnailImages = [];

    // Файлы, выбранные на форме
    //var files = event.target.files;

    // FileList и ForEach напрямую несовместимы, поэтому:
    Array.from(event.target.files).forEach(
      (file: any) => {
        if (file) {

          // Проверка размера файла
          var size = file.size;
          if(size > 10000000) {// размер в байтах, ~10 МБ
            // Сообщает об ошибке
            this.toastService.show(
              'Файл слишком объемный!',
              {classname: 'bg-warning text-dark'});

            // Удаляет выбранные на форме файлы
            //this.myInputVariable.nativeElement.value = "";
          }
          else {

            // Отключить защиту ссылок
            // https://angular.io/api/platform-browser/DomSanitizer#description
            var uri = this.sanitizer.bypassSecurityTrustResourceUrl(
              URL.createObjectURL(file));

            // Создает модель файла
            const model: Partial<IThumbnailImage> = {
              id: this.fileId++,
              uri: uri,
              file: file
            };
              
            // Добавляет его в массив 
            this.thumbnailImages.push(new ThumbnailImage(model));
          }
        }
    });
  }

  // Нажатие на кнопку "Добавить объявление"
  submit()
  {
    // Если нет авторизации
    if (!this.authService.isAuth) {
      this.router.navigate(['/', 'login']);
    }

    // Если форма неправильно заполнена
    if (this.form.invalid) {
      return;
    }

    // Разбивает строку на таги
    var tagStr = this.input_tags.value;
    if(tagStr != null)
    {
      var tagStr_ = tagStr.replace(/[~!@"'#$%^:;&?*()+=\s]/g, ' ');
      var arrayOfStrings = tagStr_.split(/[\s,]+/);
    }

    // Создает DTO объявления
    const model: Partial<ICreateAdvertisement> = {
      title: this.title.value,
      body: this.body.value,
      price: this.price.value,
      categoryId: +this.categoryId.value,
      regionId: this.regionId.value,
      address: this.address.value,
      tagBodies: arrayOfStrings,
      status: this.status.value,
    };

    // Добавляет JSON к FormData
    this.formData.append(
      'jsonString',
      JSON.stringify(model));
    
    // Добавляет все выбранные файлы к FormData
    this.thumbnailImages.forEach(item => {
      this.formData.append(
        "Files",
        item.file);
    })

    // Отправлет DTO объявления на бэк
    this.advertisementService.create(this.formData)
      .pipe(take(1)).subscribe((res) => {
        // Выдаёт всплывающее сообщение о результате
        this.toastService.show(
          'Объявление успешено добавлено',
          {classname: 'bg-success text-light'});

        // Определяем идентификатор вновь созданного объявления
        let id = JSON.parse(JSON.stringify(res)).id;
        
        // Переходит на страницу вновь созданного объявления
        this.router.navigate(['/'+id]);
      });
  }
}