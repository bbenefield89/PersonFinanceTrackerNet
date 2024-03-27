import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './views/landing-page/landing-page.component';
import { SignupLoginPageComponent } from './views/signup-login-page/signup-login-page.component';
import { DashboardPageComponent } from './views/dashboard-page/dashboard-page.component';

const routes: Routes = [
    { path: "", component: LandingPageComponent },
    { path: "signup", component: SignupLoginPageComponent },
    { path: "dashboard", component: DashboardPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
