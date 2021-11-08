import { Component, ChangeDetectionStrategy, Output, EventEmitter,  OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
 import {MatInputModule} from '@angular/material/input';
 import { MatSliderModule } from '@angular/material/slider';
 import { FileUploadModule } from 'ng2-file-upload';
 import { FileUploader } from 'ng2-file-upload';
 import {MatFormFieldModule} from '@angular/material/form-field';
 import { AuthService, Tag, ICategory} from './../../services/auth.service';
 import {COMMA, ENTER} from '@angular/cdk/keycodes'; 
 import {MatChipInputEvent} from '@angular/material/chips';
 import {EMPTY, Observable} from 'rxjs';
 import {CategoryService} from './../../services/category.service';
 import {catchError} from 'rxjs/operators';
 import {Router} from '@angular/router';

@Component({
  selector: 'app-create-announcement-form',
  templateUrl: './create-announcement-form.component.html',
  styleUrls: ['./create-announcement-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush // позволяет избежать лишних проверок на изменение - в результате чего Angular начинает работать гораздо быстрее
})
export class CreateAnnouncementFormComponent implements OnInit {
  value = ''
    categories$!: Observable<ICategory[]>;
  
  constructor(
    private categoryService: CategoryService,
    private router: Router,) {   
     }
  ngOnInit() {
    this.categories$ = this.categoryService.getCategoryList({
       pageSize: 100,
       page: 0,
     });


  }
  @Output() submitEvent = new EventEmitter();
  formGroup = new FormGroup({
    title: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    body: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    categoryId: new FormControl('', [Validators.required]),  
    tagBodies: new FormControl(''),
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
 
  get tagBodiesControl() {
    return this.formGroup.get('tagBodies');
   }


  
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  tagBodies: Tag[] = [
    {name: 'Lemon'},
    {name: 'Lime'},
    {name: 'Apple'}, 
  ];

add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    // Добавить тег
    if (value) {
      this.tagBodies.push({name: value});
  }

    // Удалить тег
    event.chipInput!.clear();
   }

  remove(tagBody: Tag): void {
    const index = this.tagBodies.indexOf(tagBody);

    if (index >= 0) {
      this.tagBodies.splice(index, 1);
    }
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
