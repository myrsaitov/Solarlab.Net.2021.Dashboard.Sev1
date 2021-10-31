import { Component, OnInit } from '@angular/core';
import { AuthService, АnnouncementDTO } from './../services/auth.service'; 
import { Router } from '@angular/router';


@Component({
  selector: 'app-create-announcement',
  templateUrl: './create-announcement.component.html',
  styleUrls: ['./create-announcement.component.scss']
})
export class CreateAnnouncementComponent {
  
    constructor(private _authService: AuthService, private router: Router) { }

  
 
   create(event: АnnouncementDTO) {
      this._authService.create(event).subscribe(res => {
        console.log(res);
      });

  this.router.navigateByUrl('/') 
  }
 }


