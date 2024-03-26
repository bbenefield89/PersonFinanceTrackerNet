import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignupLoginPageComponent } from './signup-login-page.component';

describe('SignupLoginPageComponent', () => {
  let component: SignupLoginPageComponent;
  let fixture: ComponentFixture<SignupLoginPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SignupLoginPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SignupLoginPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
