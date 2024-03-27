import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignupLoginPageComponent } from './signup-login-page.component';
import { Component, EventEmitter, Output } from '@angular/core';
import { By } from '@angular/platform-browser';

@Component({
    selector: "app-signup-form",
    template: "<div></div>",
})
class MockSignupFormComponent {
    @Output() toggleForms = new EventEmitter<void>()
}

@Component({
    selector: "app-login-form",
    template: "<div></div>"
})
class MockLoginFormComponent {
    @Output() toggleForms = new EventEmitter<void>()
}

describe('SignupLoginPageComponent', () => {
    let component: SignupLoginPageComponent;
    let fixture: ComponentFixture<SignupLoginPageComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [
                SignupLoginPageComponent,
                MockSignupFormComponent,
                MockLoginFormComponent,
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

    it("should toggle the state of property 'showSignupForm' when toggleForms is called", () => {
        expect(component.showSignupForm).toBeTruthy()
        component.toggleForms()
        expect(component.showSignupForm).toBeFalsy()
    })

    it("should call toggleForms when 'toggleForms' event is emitted from SignupFormComponent", () => {
        const toggleFormsSpy = spyOn(component, "toggleForms")
        const childComponentDE = fixture.debugElement.query(By.directive(MockSignupFormComponent))
        const childComponent: MockSignupFormComponent = childComponentDE.componentInstance

        childComponent.toggleForms.emit()
        expect(toggleFormsSpy).toHaveBeenCalled()
    })

    it("should call toggleForms when 'toggleForms' event is emitted from LoginFormComponent", () => {
        component.showSignupForm = false
        fixture.detectChanges()

        const toggleFormsSpy = spyOn(component, "toggleForms")
        const childComponentDE = fixture.debugElement.query(By.directive(MockLoginFormComponent))
        const childComponent: MockLoginFormComponent = childComponentDE.componentInstance

        childComponent.toggleForms.emit()
        expect(toggleFormsSpy).toHaveBeenCalled()
    })

    it("should toggle property 'showErrorToast' when method 'toggleShowErrorToast' is called", () => {
        expect(component.showErrorToast).toBeFalsy()
        component.toggleShowErrorToast()
        expect(component.showErrorToast).toBeTruthy()
    })
});
