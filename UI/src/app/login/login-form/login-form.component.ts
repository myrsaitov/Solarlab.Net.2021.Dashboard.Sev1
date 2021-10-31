import { Component, ChangeDetectionStrategy, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
 import {MatInputModule} from '@angular/material/input';
 import { MatSliderModule } from '@angular/material/slider';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush // позволяет избежать лишних проверок на изменение - в результате чего Angular начинает работать гораздо быстрее
})
export class LoginFormComponent {
  @Output() submitEvent = new EventEmitter();
  hide = true;
    value = ''
  formGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)])
    
  })

  constructor() { }

  get emailControl() {
    return this.formGroup.get('email');
  }
  get passwordControl() {
    return this.formGroup.get('password');
  }
    

  submit() {
    if(this.formGroup.invalid) {
      console.error('Ошибка валидации');
      this.formGroup.markAllAsTouched(); // при отправке делает все формы использованными (если не заполнено - выведет Ввод ... обязателен)
      return;
    }

    this.submitEvent.next(this.formGroup.value); 
  }
}
