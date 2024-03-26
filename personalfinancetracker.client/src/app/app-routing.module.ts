import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './views/landing-page/landing-page.component';
import { SignupLoginPageComponent } from './views/signup-login-page/signup-login-page.component';

const routes: Routes = [
  { path: "", component: LandingPageComponent },
  { path: "signup", component: SignupLoginPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
