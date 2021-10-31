import { Component, ChangeDetectionStrategy, Output, EventEmitter,  OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
 import {MatInputModule} from '@angular/material/input';
 import { MatSliderModule } from '@angular/material/slider';
 import { FileUploadModule } from 'ng2-file-upload';
 import { FileUploader } from 'ng2-file-upload';

@Component({
  selector: 'app-create-announcement-form',
  templateUrl: './create-announcement-form.component.html',
  styleUrls: ['./create-announcement-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush // позволяет избежать лишних проверок на изменение - в результате чего Angular начинает работать гораздо быстрее
})
export class CreateAnnouncementFormComponent {
  value = ''
  uploader: FileUploader = new FileUploader({ url: "api/your_upload", removeAfterUpload: false, autoUpload: true });
  constructor() { }
  @Output() submitEvent = new EventEmitter();
  formGroup = new FormGroup({
    nameProduct: new FormControl('', [Validators.required]),
     priceProduct: new FormControl('', [Validators.required]),
     descriptionProduct: new FormControl('', [Validators.required]),
     addressProduct: new FormControl('', [Validators.required]) 
  })

   get nameProductControl() {
     return this.formGroup.get('nameProduct');
   }

   get priceProductControl() {
    return this.formGroup.get('priceProduct');
  }

   get descriptionProductControl() {
     return this.formGroup.get('descriptionProduct');
   }

   get addressProductControl() {
     return this.formGroup.get('addressProduct');
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
