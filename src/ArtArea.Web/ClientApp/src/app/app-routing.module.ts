import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// place there component imports

import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';

const routes: Routes = [
  // place there routes
  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginPageComponent, data: {redirectTo : ''} },
  { path: 'register', component: RegisterPageComponent },
  { path: 'user/:username', component: UserPageComponent },
  { path: '**', component: NotFoundPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
