import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing"
import { SignupFormComponent } from './signup-form.component';
import { UserRegistrationService } from '../../services/user-registration/user-registration.service';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { of } from 'rxjs';
import { JwtService } from '../../services/jwt/jwt.service';
import { Router } from '@angular/router';

class MockUserRegistrationService {
    registerUser = jasmine.createSpy("registerUser").and.returnValue(of({}))
}

describe('SignupFormComponent', () => {
    let component: SignupFormComponent;
    let fixture: ComponentFixture<SignupFormComponent>;
    let userRegistrationService: UserRegistrationService;
    let jwtService: JwtService;
    let router: Router;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [SignupFormComponent],
            imports: [
                HttpClientTestingModule,
                ReactiveFormsModule,
            ],
            providers: [
                FormBuilder,
                JwtService,
                Router,
                { provide: UserRegistrationService, useClass: MockUserRegistrationService },
            ],
        })
            .compileComponents();

        fixture = TestBed.createComponent(SignupFormComponent);
        component = fixture.componentInstance;
        userRegistrationService = TestBed.inject(UserRegistrationService)
        jwtService = TestBed.inject(JwtService)
        router = TestBed.inject(Router)
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it("should call UserRegistration::registerUser when submitSignupForm is called", () => {
        const formData = { username: "username", password: "password", email: "email@email.com" }
        component.signupForm.setValue(formData)
        component.submitSignupForm()
        expect(userRegistrationService.registerUser).toHaveBeenCalledWith(formData)
    })

    it("should call submitSignupForm on signup form button click", () => {
        spyOn(component, "submitSignupForm")

        const signupFormBtn = fixture.nativeElement.querySelector("[type=submit")
        signupFormBtn.click()

        expect(component.submitSignupForm).toHaveBeenCalled()
    })

    it("should call submitSignupFormNext on successful user registration", () => {
        spyOn(component, "submitSignupFormNext")
        component.submitSignupForm()
        expect(component.submitSignupFormNext).toHaveBeenCalled()
    })

    it("should set jwt on successful registration", () => {
        const submitSignupFormResponse = { token: "abc123", message: "Success" }
        const tokenSetterSpy = spyOnProperty(jwtService, "token", "set")

        component.submitSignupFormNext(submitSignupFormResponse)
        expect(tokenSetterSpy).toHaveBeenCalled()
    })

    it("should navigate to /dashboard on successful registration", () => {
        const navigateByUrlSpy = spyOn(router, "navigateByUrl")

        component.submitSignupFormNext({ token: "", message: "" })
        expect(navigateByUrlSpy).toHaveBeenCalledWith("/dashboard")
    })

    it("should call handleLoginButtonClick on login button click", () => {
        const spy = spyOn(component, "handleLoginButtonClick")
        const loginBtn = fixture.nativeElement.querySelector("#showLogin")
        loginBtn.click()
        expect(spy).toHaveBeenCalled()
    })

    it("should emit toggleForms when handleLoginButtonClick is called", () => {
        const toggleFormsSpy = spyOn(component.toggleForms, "emit")

        component.handleLoginButtonClick()
        expect(toggleFormsSpy).toHaveBeenCalled()
    })
});
