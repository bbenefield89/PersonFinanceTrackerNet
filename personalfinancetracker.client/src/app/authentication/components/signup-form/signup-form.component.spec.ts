import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from "@angular/common/http/testing"
import { SignupFormComponent } from './signup-form.component';
import { UserRegistrationService } from '../../services/user-registration/user-registration.service';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';

describe('SignupFormComponent', () => {
    let component: SignupFormComponent;
    let fixture: ComponentFixture<SignupFormComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [SignupFormComponent],
            imports: [
                HttpClientTestingModule,
                ReactiveFormsModule,
            ],
            providers: [
                FormBuilder,
                UserRegistrationService,
            ],
        })
            .compileComponents();

        fixture = TestBed.createComponent(SignupFormComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
