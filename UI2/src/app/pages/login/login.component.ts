import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ILogin} from 'src/app/models/account/login.model';
import {BaseService} from 'src/app/services/base.service';
import {ApiUrls} from 'src/app/shared/apiURLs';
import {Router} from '@angular/router';
import {AuthService} from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  notloginedstatus = false;
  passwordHide : boolean = true; // Показать/спрятать пароль

  private formObj = {
    eMail: ['user@mail.ru', [Validators.required, Validators.email]],
    password: ['Zuse123!@#$%^()', [Validators.required, Validators.min(6),Validators.min(20)]],
    rememberMe: [false]
  };

  constructor(
    private readonly baseService: BaseService,
    private readonly router: Router,
    private readonly auth: AuthService,
    private fb: FormBuilder,
  ) {
    this.loginForm = fb.group(this.formObj);
  }

  ngOnInit() {

  }

  get eMail() {
    return this.loginForm.get('eMail');
  }

  get password() {
    return this.loginForm.get('password');
  }

  onCheckboxChange(event: any) {
    this.passwordHide = !this.passwordHide;
  }

  
  public async login() {
    this.loginForm.markAllAsTouched();
    if (this.loginForm.invalid) {
      return;
    }
    const payload: ILogin = this.loginForm.getRawValue();

    localStorage.setItem('currentUser', payload.eMail);
   
    await this.baseService.post(ApiUrls.login, payload)
      .then(res => {
        if (res) {
          // Сохраняет сессию
          this.auth.saveSession(res);

          // Открывает главную страницу
          this.router.navigate(['/']);
        }
          else{this.notloginedstatus = true;}
      });
}




      
  
}
