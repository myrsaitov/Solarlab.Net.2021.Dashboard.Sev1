import { Component, OnInit } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import { MatSliderModule } from '@angular/material/slider';
import {FormControl, Validators} from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})



export class LoginComponent {
  // title = 'my-app'; 
  hide = true;
  value = ''
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
}

