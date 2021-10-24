import { Component, OnInit, ChangeDetectionStrategy, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
 import {MatInputModule} from '@angular/material/input';
 import { MatSliderModule } from '@angular/material/slider';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
 // changeDetection: ChangeDetectionStrategy.OnPush // позволяет избежать лишних проверок на изменение - в результате чего Angular начинает работать гораздо быстрее
})
export class RegistrationFormComponent  {
  value = ''
  hide = true;
  @Output() submitEvent = new EventEmitter();
  formGroup = new FormGroup({
    login: new FormControl('', [Validators.required, Validators.minLength(4)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    tel: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    repeatPassword: new FormControl('', [Validators.required, Validators.minLength(8)]),
  })
  get loginControl() {
    return this.formGroup.get('login');
  }

  get emailControl() {
    return this.formGroup.get('email');
  }

  get telControl() {
    return this.formGroup.get('tel');
  }

  get passwordControl() {
    return this.formGroup.get('password');
  }
  get repeatPasswordControl() {
    return this.formGroup.get('repeatPassword');
  }

    constructor() { }

  submit() {
    if(this.formGroup.invalid) {
      console.error('Ошибка валидации');
      this.formGroup.markAllAsTouched();
      return;
    }

    this.submitEvent.next(this.formGroup.value);
  }
}
