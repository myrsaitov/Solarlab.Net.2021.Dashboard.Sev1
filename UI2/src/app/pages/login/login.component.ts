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

  private formObj = {
    eMail: [null, [Validators.required, Validators.email]],
    password: [null, [Validators.required, Validators.min(8)]],
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
          this.auth.saveSession(res);
          this.router.navigate(['/']);
        }
          else{this.notloginedstatus = true;}
      });
}




      
  
}
