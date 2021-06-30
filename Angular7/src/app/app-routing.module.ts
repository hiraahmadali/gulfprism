import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { CompanyComponent } from './company/company.component';
import { OrderComponent } from './order/order.component';
import { ListCompanyComponent } from './company/list-company/list-company.component';
import { AddCompanyComponent } from './company/add-company/add-company.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {
    path:'home',component:HomeComponent,canActivate:[AuthGuard],
    children: [
      {path:'company',component:CompanyComponent},
      {path: 'add-company', component:AddCompanyComponent},
      {path:'orders',component:OrderComponent},
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
