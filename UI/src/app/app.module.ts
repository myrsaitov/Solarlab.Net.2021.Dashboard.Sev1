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
    RegistrationFormComponent
    
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
    MatCardModule    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
