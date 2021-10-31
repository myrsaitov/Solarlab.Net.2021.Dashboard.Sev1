import { AuthService, IUserLoginDTO } from './../services/auth.service'; 
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
    const model: IUserLoginDTO = {
      email: loginModel.email,  
       password: loginModel.password
    }
     this.router.navigateByUrl('/') 
     this._authService.login(loginModel).subscribe(res => {    
 
     });
  }
 
  
}




