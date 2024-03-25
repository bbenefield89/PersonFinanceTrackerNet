import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { SignupLoginPageComponent } from './signup-login-page/signup-login-page.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SignupFormComponent } from './signup-form/signup-form.component';
import { LoginFormComponent } from './login-form/login-form.component';

@NgModule({
    declarations: [
        AppComponent,
        LandingPageComponent,
        SignupLoginPageComponent,
        NavBarComponent,
        SignupFormComponent,
        LoginFormComponent,
    ],
    imports: [
        BrowserModule, HttpClientModule,
        AppRoutingModule,
        ReactiveFormsModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
