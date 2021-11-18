import { Component, ChangeDetectionStrategy, Output, EventEmitter,  OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
 import {MatInputModule} from '@angular/material/input';
 import { MatSliderModule } from '@angular/material/slider';
 import { FileUploadModule } from 'ng2-file-upload';
 import { FileUploader } from 'ng2-file-upload';
 import {MatFormFieldModule} from '@angular/material/form-field';
 import { AuthService, Tag, ICategory,IRegion} from './../../services/auth.service';
 import {COMMA, ENTER} from '@angular/cdk/keycodes'; 
 import {MatChipInputEvent} from '@angular/material/chips';
 import {EMPTY, Observable} from 'rxjs';
 import {CategoryService} from './../../services/category.service';
 import {RegionService} from './../../services/region.service';
 import {catchError, subscribeOn} from 'rxjs/operators';
 import {Router} from '@angular/router';
 import {MatFormFieldControl} from '@angular/material/form-field';
 import {map, startWith} from 'rxjs/operators';
 @Component({
  selector: 'app-create-announcement-form',
  templateUrl: './create-announcement-form.component.html',
  styleUrls: ['./create-announcement-form.component.scss'],
  providers: [
    { provide: MatFormFieldControl, useExisting: CreateAnnouncementFormComponent}   //если будут проблеммы- удалить
  ],
  changeDetection: ChangeDetectionStrategy.OnPush // позволяет избежать лишних проверок на изменение - в результате чего Angular начинает работать гораздо быстрее
})
export class CreateAnnouncementFormComponent implements OnInit {
  value = ''
    categories$!: Observable<ICategory[]>;
    regions$!: Observable<IRegion[]>;
  constructor(
    private categoryService: CategoryService,
    private regionService: RegionService,
    private router: Router,) {   
     }
  ngOnInit() {
    this.categories$ = this.categoryService.getCategoryList({
       pageSize: 100,
       page: 0,
        });
        this.regions$ = this.regionService.getRegionList({
          pageSize: 100,
          page: 0,
           });

        /* let categories = [];
         this
             .categoryService
             .getCategoryList({pageSize: 100, page: 0})
             .subscribe(
                 (res) => 
                 { //map это как foreach
                     res.map(item => 
                     {
                         if (item.parentCategoryId === null) // Значит это верхний уровень
                         {
                            
                             item.children = res.filter(
                                 el => el.parentCategoryId === item.id);

                             categories.push(item);
                          }
                     })
                 })*/

  
  }
  @Output() submitEvent = new EventEmitter();
  formGroup = new FormGroup({
    title: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    body: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    categoryId: new FormControl('', [Validators.required]), 
    regionId: new FormControl('', [Validators.required]),  
    // tagBodies: new FormControl(''),
  })

 
   get titleControl() {
     return this.formGroup.get('title');
   }

   get priceControl() {
    return this.formGroup.get('price');
  }

   get bodyControl() {
     return this.formGroup.get('body');
   }

   get addressControl() {
     return this.formGroup.get('address');
   }
 
    get categoryIdControl() {
    return this.formGroup.get('categoryId');
   }
   get regionIdControl() {
    return this.formGroup.get('regionId');
   }
  

     submit() {
     if(this.formGroup.invalid) {
      console.error('Ошибка валидации');
       this.formGroup.markAllAsTouched();
      return;
   }
  
     this.submitEvent.next(this.formGroup.value);
   }
}
