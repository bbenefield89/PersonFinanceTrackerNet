import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './views/landing-page/landing-page.component';
import { SignupLoginPageComponent } from './views/signup-login-page/signup-login-page.component';
import { NavBarComponent } from './globals/nav-bar/nav-bar.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        declarations: [
            AppComponent,
            LandingPageComponent,
            SignupLoginPageComponent,
            NavBarComponent
        ],
        imports: [
            BrowserModule, HttpClientModule,
            AppRoutingModule
        ],
    }).compileComponents();

    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });
});
