import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { SignupLoginPageComponent } from './signup-login-page/signup-login-page.component';

const routes: Routes = [
  { path: "", component: LandingPageComponent },
  { path: "signup", component: SignupLoginPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
