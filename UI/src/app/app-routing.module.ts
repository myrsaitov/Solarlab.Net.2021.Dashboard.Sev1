import { NgModule } from '@angular/core';
import { AuthGuard } from './guards/auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { CreateAnnouncementComponent } from './create-announcement/create-announcement.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CardComponent } from './dashboard/card/card.component';
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
    path: 'dashboard', component: DashboardComponent
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard]   //только при наличии токена админа пустит на страничку админ
  },
  {
    path: 'dashboard/:id',  component: CardComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
 
 }
