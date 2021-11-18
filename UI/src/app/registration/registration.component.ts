import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { AuthService, IUserRegisterDTO } from './../services/auth.service'; 
import { Router } from '@angular/router';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
  
})
export class RegistrationComponent {
  
   constructor(private _authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

   registration(event: IUserRegisterDTO) {
        this._authService.register(event).subscribe(res => {
          console.log(res);
        });
        this.router.navigateByUrl('authentication')
   }
  
}
