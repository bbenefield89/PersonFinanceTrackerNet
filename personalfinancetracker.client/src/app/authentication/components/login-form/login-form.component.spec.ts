import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginFormComponent } from './login-form.component';

describe('LoginFormComponent', () => {
    let component: LoginFormComponent;
    let fixture: ComponentFixture<LoginFormComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [LoginFormComponent]
        })
            .compileComponents();

        fixture = TestBed.createComponent(LoginFormComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it("Should call handleLoginButtonClick on login button click", () => {
        spyOn(component, "handleLoginButtonClick")

        const loginBtn = fixture.nativeElement.querySelector("[type=submit]")
        loginBtn.click()

        expect(component.handleLoginButtonClick).toHaveBeenCalled()
    })

    it("should call handleSignupButtonClick on signup button click", () => {
        spyOn(component, "handleSignupButtonClick")

        const signupBtn = fixture.nativeElement.querySelector("#showSignup")
        signupBtn.click()

        expect(component.handleSignupButtonClick).toHaveBeenCalled()
    })

    it("Should emit 'toggleForms' when handleSignupButtonClick is called", () => {
        spyOn(component.toggleForms, "emit")
        component.handleSignupButtonClick()
        expect(component.toggleForms.emit).toHaveBeenCalled()
    })
});
