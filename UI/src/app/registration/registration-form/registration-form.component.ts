import { Component, OnInit, ChangeDetectionStrategy, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
 import {MatInputModule} from '@angular/material/input';
 import { MatSliderModule } from '@angular/material/slider';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush // позволяет избежать лишних проверок на изменение - в результате чего Angular начинает работать гораздо быстрее
})
export class RegistrationFormComponent  {
  value = ''
  hide = true;
  @Output() submitEvent = new EventEmitter();
  formGroup = new FormGroup({
    userName: new FormControl('', [Validators.required, Validators.minLength(5)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,20}$")]),
    repeatPassword: new FormControl('', [Validators.required, Validators.minLength(6), Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,20}$")]),
    regionId: new FormControl('1'), //временная затычка, что бы работал бэк
    firstName: new FormControl('User'),//временная затычка, что бы работал бэк
   lastName: new FormControl('User'),//временная затычка, что бы работал бэк
   middleName: new FormControl('User'),//временная затычка, что бы работал бэк
  }) 
  
  

  get userNameControl() {
    return this.formGroup.get('userName');
  }

  get emailControl() {
    return this.formGroup.get('email');
  }

  get phoneNumberControl() {
    return this.formGroup.get('phoneNumber');
  }

  get passwordControl() {
    return this.formGroup.get('password');
  }
  get repeatPasswordControl() {
    return this.formGroup.get('repeatPassword');
  }
  
  get regionIdControl() {
    return this.formGroup.get('1');
  }

  get firstNameControl() {
    return this.formGroup.get('User');
  }
  get lastNameControl() {
    return this.formGroup.get('User');
  }
  get middleNameIdControl() {
    return this.formGroup.get('User');
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
