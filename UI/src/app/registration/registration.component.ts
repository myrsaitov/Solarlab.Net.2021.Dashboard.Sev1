import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { AuthService, UserRegisterDTO } from './../services/auth.service'; 

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
  
})
export class RegistrationComponent {
  
   constructor(private _authService: AuthService) { }

  ngOnInit(): void {
  }

   registration(event: UserRegisterDTO) {
        this._authService.register(event).subscribe(res => {
          console.log(res);
        });
   }
 
}
