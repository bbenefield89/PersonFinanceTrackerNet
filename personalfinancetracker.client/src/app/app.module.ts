import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './views/landing-page/landing-page.component';
import { SignupLoginPageComponent } from './views/signup-login-page/signup-login-page.component';
import { NavBarComponent } from './globals/nav-bar/nav-bar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SignupFormComponent } from './authentication/signup-form/signup-form.component';
import { LoginFormComponent } from './authentication/login-form/login-form.component';

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
