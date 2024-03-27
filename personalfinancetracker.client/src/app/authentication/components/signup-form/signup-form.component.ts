import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserRegistrationService } from '../../services/user-registration/user-registration.service';
import { Router } from '@angular/router';

type SubmitSignupFormResponse = {
    token: string;
    message: string;
}

@Component({
  selector: 'app-signup-form',
  templateUrl: './signup-form.component.html',
  styleUrl: './signup-form.component.css'
})
export class SignupFormComponent {
    @Output() toggleForms = new EventEmitter<void>()
    public signupForm: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private userRegistrationService: UserRegistrationService,
        private router: Router)
    {
        this.signupForm = formBuilder.group({
            username: "",
            email: "",
            password: "",
        })
    }

    public submitSignupForm() {
        this.userRegistrationService
            .registerUser(this.signupForm.value)
            .subscribe({
                error: console.error,
                next: (res) => this.submitSignupFormNext(res as SubmitSignupFormResponse),
            })
    }

    public submitSignupFormNext({ token }: SubmitSignupFormResponse) {
        // save token in a global place
        // navigate to /dashboard
        this.router.navigateByUrl("/dashboard")
    }

    public handleLoginButtonClick() {
        this.toggleForms.emit()
    }
}
