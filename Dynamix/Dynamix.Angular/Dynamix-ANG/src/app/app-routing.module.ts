import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { HomeComponent } from './home/home.component';
import {LoginComponent} from './login/login.component';
import {AboutComponent} from './about/about.component';
import {CreateComponent} from './create/create.component';
import {DashboardComponent} from './dashboard/dashboard.component';

const routes: Routes = [
{path: '',  redirectTo: '/home', pathMatch: 'full'},
{path: 'home', component: HomeComponent},
{path: 'login', component: LoginComponent},
{path: 'about', component: AboutComponent},
{path: 'create', component: CreateComponent},
{path: 'dashboard', component: DashboardComponent}



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
