import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AdvertisementService} from '../../services/advertisement.service';
import {pluck, switchMap, take, takeUntil} from 'rxjs/operators';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastService} from '../../services/toast.service';
import {CategoryService} from '../../services/category.service';
import {Observable, Subject} from 'rxjs';
import {ICategory} from '../../models/category/category-model';
import {EditAdvertisement, IEditAdvertisement} from '../../models/advertisement/advertisement-edit-model';
import { TagService } from '../../services/tag.service';
import { ITag } from 'src/app/models/tag/tag-model';
import { isNullOrUndefined } from 'util';
import { IRegion } from 'src/app/models/region/region-model';
import { RegionService } from 'src/app/services/region.service';

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

  constructor(private fb: FormBuilder,
              private advertisementService: AdvertisementService,
              private categoryService: CategoryService,
              private route: ActivatedRoute,
              private router: Router,
              private toastService: ToastService,
              private tagService: TagService,
              private regionService: RegionService) {
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
      price: ['', Validators.pattern("[0-9,]*")],
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
        status: this.status.value,
      };
      this.uri = '/' + model.id;
      return this.advertisementService.edit(new EditAdvertisement(model));
    }), take(1)).subscribe(() => {
      // Выдаёт всплывающее сообщение о результате
      this.toastService.show('Объявление успешено обновлено', {classname: 'bg-success text-light'});
      
      // Переходит на страницу вновь созданного объявления
      this.router.navigate([this.uri]);
    });
  }
}