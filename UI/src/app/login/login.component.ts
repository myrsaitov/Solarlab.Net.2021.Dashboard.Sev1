import { AuthService, UserLoginDTO } from './../services/auth.service'; 
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})



export class LoginComponent {
  

   constructor(private _authService: AuthService, private router: Router) { }

  login(loginModel: any) {
    const model: UserLoginDTO = {
       email: loginModel.username,
       password: loginModel.password
    }
     this.router.navigateByUrl('/') 
     this._authService.login(loginModel).subscribe(res => {    
 
     });
  }
  
}

