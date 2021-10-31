import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import {Routes, RouterModule} from '@angular/router';
import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule  } from "@angular/forms";
import { HttpClientModule }   from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { RegistrationComponent } from './registration/registration.component';
import { AnnouncementComponent } from './announcement/announcement.component';
import { CardComponent } from './card/card.component';
import {MatCardModule} from '@angular/material/card';
import { CreateAnnouncementComponent } from './create-announcement/create-announcement.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LoginFormComponent } from './login/login-form/login-form.component';
import { RegistrationFormComponent } from './registration/registration-form/registration-form.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AdminComponent } from './admin/admin.component';
import { CreateAnnouncementFormComponent } from './create-announcement/create-announcement-form/create-announcement-form.component';
import { FileUploadModule } from 'ng2-file-upload';
import { UploadComponent } from './create-announcement/create-announcement-form/upload/upload.component';
import {MatSelectModule} from '@angular/material/select';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import {MatChipInputEvent, MatChipsModule} from '@angular/material/chips';
import { MatFileUploadModule } from 'angular-material-fileupload';
import { AuthInterceptor } from './auth.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    AnnouncementComponent,
    CardComponent,
    CreateAnnouncementComponent,
    HeaderComponent,
    FooterComponent,
    LoginFormComponent,
    RegistrationFormComponent,
    AdminComponent,
    CreateAnnouncementFormComponent,
    UploadComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, 
    MatSliderModule,
    HttpClientModule, BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    ReactiveFormsModule,
    MatButtonModule,
    FileUploadModule,
    MatSelectModule,
    MatCardModule,
    MatChipsModule,
    MatFileUploadModule
     ],


  
   providers: [{
    provide: HTTP_INTERCEPTORS,
     multi: true,
     useClass: AuthInterceptor,
   }],
  bootstrap: [AppComponent]
})
export class AppModule { }
