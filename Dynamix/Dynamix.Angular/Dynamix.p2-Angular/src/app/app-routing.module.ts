import { AboutComponent } from './about/about.component';
import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { SignUpComponent } from './users/sign-up/sign-up.component';


const routes: Routes = [
  {path: '', redirectTo: '/dashboard', pathMatch: 'full'},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'home', component: HomeComponent},
  {path: 'users', component: UsersComponent},
  {path: 'sign-up', component: SignUpComponent},
  {path: 'about', component: AboutComponent}
];

@NgModule({
imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]

})

export class AppRoutingModule {}
export const routingComponents = [DashboardComponent, HomeComponent, UsersComponent, SignUpComponent]
