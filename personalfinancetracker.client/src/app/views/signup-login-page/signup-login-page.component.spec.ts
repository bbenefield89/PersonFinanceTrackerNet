import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignupLoginPageComponent } from './signup-login-page.component';
import { Component } from '@angular/core';

@Component({
    selector: "app-signup-form",
    template: "<div></div>",
})
class MockSignupFormComponent { }

describe('SignupLoginPageComponent', () => {
    let component: SignupLoginPageComponent;
    let fixture: ComponentFixture<SignupLoginPageComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [
                SignupLoginPageComponent,
                MockSignupFormComponent,
            ]
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
