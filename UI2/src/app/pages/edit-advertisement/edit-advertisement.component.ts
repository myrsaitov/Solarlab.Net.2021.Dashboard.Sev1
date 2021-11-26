import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AdvertisementService} from '../../services/advertisement.service';
import {pluck, switchMap, take, takeUntil} from 'rxjs/operators';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastService} from '../../services/toast.service';
import {CategoryService} from '../../services/category.service';
import {Observable, Subject} from 'rxjs';
import {ICategory} from '../../models/category/category-model';
import {IEditAdvertisement} from '../../models/advertisement/advertisement-edit-model';
import { TagService } from '../../services/tag.service';
import { ITag } from 'src/app/models/tag/tag-model';
import { isNullOrUndefined } from 'util';
import { IRegion } from 'src/app/models/region/region-model';
import { RegionService } from 'src/app/services/region.service';
import { DomSanitizer} from '@angular/platform-browser';
import { IThumbnailImage, ThumbnailImage } from 'src/app/models/thumbnail-image/thumbnail-image-model';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-edit-advertisement',
  templateUrl: './edit-advertisement.component.html',
  styleUrls: ['./edit-advertisement.component.scss']
})
export class EditAdvertisementComponent implements OnInit, OnDestroy {
  form: FormGroup;
  categories$: Observable<ICategory[]>;
  regions$: Observable<IRegion[]>;
  advertisementId$ = this.route.params.pipe(pluck('id'));
  destroy$ = new Subject();
  tagstr: string;
  tags$: Observable<ITag[]>;
  uri: string;
  formData: FormData = new FormData();
  thumbnailImages: IThumbnailImage[] = [];
  fileId: number = 0; // уникальный id файла, который загружается на форму

  constructor(private fb: FormBuilder,
              private advertisementService: AdvertisementService,
              private categoryService: CategoryService,
              private route: ActivatedRoute,
              private router: Router,
              private toastService: ToastService,
              private tagService: TagService,
              private regionService: RegionService,
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

    this.form = this.fb.group({
      title: ['', Validators.required],
      body: ['', Validators.required],
      price: ['', [Validators.required, Validators.pattern("[0-9,]*")]],
      categoryId: ['', Validators.required],
      regionId: ['1', [Validators.required]],
      address: [''],
      input_tags: [''],
      status: ['', [Validators.required]],
    });
    this.advertisementId$.pipe(switchMap(advertisementId => {
      return this.advertisementService.getAdvertisementById(advertisementId);
    }), takeUntil(this.destroy$)).subscribe(advertisement => {

      this.title.patchValue(advertisement.title);
      this.body.patchValue(advertisement.body);
      this.price.patchValue(advertisement.price);
      this.categoryId.patchValue(advertisement.categoryId);
      this.regionId.patchValue(advertisement.regionId);
      this.address.patchValue(advertisement.address);
      this.tagstr = "";
      this.status.patchValue(advertisement.status);
      advertisement.tags.forEach(function (value){
        this.tagstr +=' ' + value;
      },this);

      this.input_tags.patchValue(this.tagstr);


    });
  }
  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();
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

    // FileList и ForEach напрямую несовместимы, поэтому:
    Array.from(event.target.files).forEach(
      (file: any) => {
        if (file) {

          // Проверка размера файла
          if(file.size > 10000000) {// размер в байтах, ~10 МБ
            // Сообщает об ошибке
            this.toastService.show(
              'Файл слишком объемный!',
              {classname: 'bg-warning text-dark'});
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

  // Обработка события нажатия на кнопку
  submit() {

    // Валидация формы
    if (this.form.invalid) {
      return;
    }

    // Взяли строку с тагами с формы
    var tagStr = this.input_tags.value;

    // Если строчка не пустая
    if(tagStr != null)
    {
      console.log("TAG string:");
      console.log(tagStr);

      var tagStr_ = tagStr.replace(/[~!@"'#$%^:;&?*()+=\s]/g, ' ');

      console.log("TAG string with removed non-car symbols:");
      console.log(tagStr_);

      var arrayOfStrings = tagStr_.split(/[\s,]+/);
      console.log("Splitted TAG string:");
      console.log(arrayOfStrings);
    }

    this.advertisementId$.pipe(switchMap(id => {
      const model: Partial<IEditAdvertisement> = {
        id: +id,
        title: this.title.value,
        body: this.body.value,
        price: this.price.value,
        tagBodies: arrayOfStrings,
        categoryId: +this.categoryId.value,
        regionId: this.regionId.value,
        address: this.address.value,
        status: this.status.value
      };
      
      // Создает ссылку на отредактированное объявление
      this.uri = '/' + model.id;

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

      return this.advertisementService.edit(this.formData);
    }), take(1)).subscribe(() => {
      // Выдаёт всплывающее сообщение о результате
      this.toastService.show(
        'Объявление успешено обновлено',
        {classname: 'bg-success text-light'});
      
      // Переходит на страницу отредактированного объявления
      this.router.navigate([this.uri]);
    });
  }
}