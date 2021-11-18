import { Component, OnInit } from '@angular/core';
import { AuthService, IАnnouncementDTO, IUploadDTO } from './../services/auth.service'; 
import { Router } from '@angular/router';


@Component({
  selector: 'app-create-announcement',
  templateUrl: './create-announcement.component.html',
  styleUrls: ['./create-announcement.component.scss']
})
export class CreateAnnouncementComponent {
  
   private advId = 0;

    constructor(private _authService: AuthService, private router: Router) { }

  
 
   create(event: IАnnouncementDTO) {

      this._authService.create(event).subscribe(res => {
         console.log(res);
         this.advId = JSON.parse(JSON.stringify(res));
        });

        // const formData = new FormData();
///https://www.freecodecamp.org/news/formdata-explained/ сделать завтра по этому примеру  скорее всего поменяется строчка 28 и ниже. попробовать загрузить файл
        // formData.append('files', multipleFile.files[0], 'chris1.jpg');

        
        // let files :IUploadDTO = {
        //   data: formData
        // }

        // this._authService.upload(files).subscribe(res => {
        //   console.log(res);
        //   this.advId = JSON.parse(JSON.stringify(res));
        //  });

        
   this.router.navigateByUrl('dashboard') 
  }
 }


