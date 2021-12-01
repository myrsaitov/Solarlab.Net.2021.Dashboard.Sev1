import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { confirmPasswordValidator } from '../../directives/confirm-password-validator.directive';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ApiUrls } from 'src/app/shared/apiURLs';
import { ILogin } from 'src/app/models/account/login.model';
import { BaseService } from 'src/app/services/base.service';
import { Observable } from 'rxjs';
import { IRegion } from 'src/app/models/region/region-model';
import { RegionService } from 'src/app/services/region.service';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})

export class SignupComponent implements OnInit {
  form: FormGroup;
  regions$: Observable<IRegion[]>;
  notregisterstatus = false;
  passwordHide : boolean = true; // Показать/спрятать пароль
  pattern = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,20}$/g;

  constructor(
    private readonly fb: FormBuilder, 
    private readonly accountService: AccountService,
    private readonly auth: AuthService,
    private readonly baseService: BaseService,
    private readonly router: Router,
    private readonly regionService: RegionService) {
  }

  // Обработка события инициализации
  ngOnInit() {
    
    // Подписка на регионы
    this.regions$ = this.regionService.getRegionList({
      pageSize: 1000,
      page: 0,
    });

    this.form = this.fb.group({
      eMail: ['user@mail.ru', [Validators.required, Validators.minLength(5), Validators.maxLength(254), Validators.email]],
      userName: ['myrsaitov', [Validators.required, Validators.minLength(5), Validators.maxLength(30), Validators.pattern("[a-zA-Z_][a-zA-Z0-9_]*")]],
      phoneNumber: ['+79787713935', [Validators.minLength(4), Validators.maxLength(15), Validators.pattern("^[0-9+]*$")]],
      firstName: ['Константин', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
      lastName: ['Мирсаитов', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
      middleName: ['Михайлович', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
      address: ['г. Севастополь, ул. Новороссийская', [Validators.minLength(10), Validators.maxLength(100)]],
      regionId: ['3', [Validators.required]],
      password: ['Zuse123!@#', [Validators.required, Validators.minLength(6), Validators.maxLength(20), Validators.pattern(this.pattern)]],
      confirmPassword: ['Zuse123!@#', [Validators.required, Validators.minLength(6), Validators.maxLength(20)]]
    }, {validators: confirmPasswordValidator});
  }

  // Возвращает значение c формы соответсвующего поля
  get eMail() { return this.form.get('eMail'); }
  get userName() { return this.form.get('userName'); }
  get phoneNumber() { return this.form.get('phoneNumber'); }
  get firstName() { return this.form.get('firstName'); }
  get lastName() { return this.form.get('lastName'); }
  get middleName() { return this.form.get('middleName'); }
  get address() { return this.form.get('address'); }
  get regionId() { return this.form.get('regionId'); }
  get password() { return this.form.get('password'); }
  get confirmPassword() { return this.form.get('confirmPassword'); }

  // Обработка события нажатия на CheckBox: Показать-спрятать пароль
  onCheckboxChange(event: any) {
    this.passwordHide = !this.passwordHide;

    if(!this.passwordHide)
    {
      // Если пароль видимый, то не проверяем confirmPassword
      this.form = this.fb.group({
        eMail: ['user@mail.ru', [Validators.required, Validators.minLength(5), Validators.maxLength(254), Validators.email]],
        userName: ['myrsaitov', [Validators.required, Validators.minLength(5), Validators.maxLength(30), Validators.pattern("[a-zA-Z_][a-zA-Z0-9_]*")]],
        phoneNumber: ['+79787713935', [Validators.minLength(4), Validators.maxLength(15), Validators.pattern("^[0-9+]*$")]],
        firstName: ['Константин', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
        lastName: ['Мирсаитов', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
        middleName: ['Михайлович', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
        address: ['г. Севастополь, ул. Новороссийская', [Validators.minLength(10), Validators.maxLength(100)]],
        regionId: ['3', [Validators.required]],
        password: ['Zuse123!@#', [Validators.required, Validators.minLength(6), Validators.maxLength(20), Validators.pattern(this.pattern)]],
        confirmPassword: ['Zuse123!@#', [Validators.required, Validators.minLength(6), Validators.maxLength(20)]]
      }, {validators: []});
    }
    else
    {
      // Если пароль скрыт, то не проверяем confirmPassword
      this.form = this.fb.group({
        eMail: ['user@mail.ru', [Validators.required, Validators.minLength(5), Validators.maxLength(254), Validators.email]],
        userName: ['myrsaitov', [Validators.required, Validators.minLength(5), Validators.maxLength(30), Validators.pattern("[a-zA-Z_][a-zA-Z0-9_]*")]],
        phoneNumber: ['+79787713935', [Validators.minLength(4), Validators.maxLength(15), Validators.pattern("^[0-9+]*$")]],
        firstName: ['Константин', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
        lastName: ['Мирсаитов', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
        middleName: ['Михайлович', [Validators.minLength(1), Validators.maxLength(30), Validators.pattern("[A-ZА-ЯЁ][a-zа-яё]*")]],
        address: ['г. Севастополь, ул. Новороссийская', [Validators.minLength(10), Validators.maxLength(100)]],
        regionId: ['3', [Validators.required]],
        password: ['Zuse123!@#', [Validators.required, Validators.minLength(6), Validators.maxLength(20), Validators.pattern(this.pattern)]],
        confirmPassword: ['Zuse123!@#', [Validators.required, Validators.minLength(6), Validators.maxLength(20)]]
      }, {validators: confirmPasswordValidator});
    }
  }

  // Нажатие на кнопку "Зарегистрироваться"
  public async register() {

    console.log("Called register()");

    // Если форма не валидна
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    // Вызываем запрос на регистрацию пользователя
    var res = await this.accountService
      .register(this.form.value)
      .toPromise();

    // Если регистрация удачная, то сразу логинимся
    if(res)
    {
      // Отметить все поля формы как "затронутые",
      // чтобы валидатор активизировался
      this.form.markAllAsTouched();

      // Если поля в форме не прошли валидацию, то выход
      if (this.form.invalid) 
      {  
        return;
      }
    
      const payload: ILogin = this.form.getRawValue();

      await this.baseService.post(ApiUrls.login, payload)
        .then(res => {
          if (res) {
            this.auth.saveSession(res);
            this.router.navigate(['/']);
          }
        });
    }
    else
    {
      this.notregisterstatus = true;
    }
  }
}