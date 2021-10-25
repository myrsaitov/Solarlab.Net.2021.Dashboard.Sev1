import { NgModule } from '@angular/core';
import { AuthGuard } from './guards/auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { CreateAnnouncementComponent } from './create-announcement/create-announcement.component';
import { AdminComponent } from './admin/admin.component';
const routes: Routes = [
  { 
    path: 'authentication', component: LoginComponent
  },
  { 
    path: 'registration', component: RegistrationComponent
  },
  { 
    path: 'сreate-аnnouncement', component: CreateAnnouncementComponent
  },
  { 
    path: 'edit-аnnouncement', component: CreateAnnouncementComponent
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard]   //только при наличии токена админа пустит на страничку админ
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
 
 }
