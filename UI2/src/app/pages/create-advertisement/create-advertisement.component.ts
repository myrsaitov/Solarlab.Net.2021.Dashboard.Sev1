import {Component, OnInit} from '@angular/core';
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

  constructor(private fb: FormBuilder,
              private advertisementService: AdvertisementService,
              private categoryService: CategoryService,
              private router: Router,
              private toastService: ToastService,
              private tagService: TagService,
              private regionService: RegionService,
              private authService: AuthService,) {
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

    // Разбиваем строку на таги
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

    // Отправлет DTO объявления на бэк
    this.advertisementService.create(new CreateAdvertisement(model))
      .pipe(take(1)).subscribe((res) => {
        
        // Определяем идентификатор вновь созданного объявления
        let id = JSON.parse(JSON.stringify(res)).id;
        
        // Выдаёт всплывающее сообщение о результате
        this.toastService.show('Объявление успешено добавлено', {classname: 'bg-success text-light'});
        
        // Переходит на страницу вновь созданного объявления
        this.router.navigate(['/'+id]);
      });
  }
}