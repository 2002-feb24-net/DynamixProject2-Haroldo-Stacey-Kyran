import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import {LoginComponent} from './login/login.component';

const routes: Routes = [
{path: '', pathMatch: 'full', redirectTo: 'home'},
{path: 'home', component: HomeComponent},
{path: '', component: LoginComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
