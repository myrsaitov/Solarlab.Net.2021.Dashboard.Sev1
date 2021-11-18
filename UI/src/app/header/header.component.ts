import { Component, OnInit } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import { MatSliderModule } from '@angular/material/slider';
import { AuthService } from './../services/auth.service'; 

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  
  constructor(public authService: AuthService) { }

  ngOnInit(): void {
  }
  logout() {
    this.authService.logout();
  }
}
