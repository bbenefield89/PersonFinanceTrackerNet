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

    it("should show signup form by default & hide login form by default", () => {
        const signupForm = fixture.nativeElement.querySelector("#signupForm")
        const loginForm = fixture.nativeElement.querySelector("#loginForm")

        expect(signupForm).not.toBeNull()
        expect(signupForm.classList.contains("hidden")).toBeFalsy()

        expect(loginForm).not.toBeNull()
        expect(loginForm.classList.contains("hidden")).toBeTruthy()
    })

    it('should toggle signup forms', () => {
        expect(component.showLoginForm).toEqual(false);

        component.toggleForms()
        expect(component.showLoginForm).toEqual(true);

        component.toggleForms()
        expect(component.showLoginForm).toEqual(false);
    });
});
