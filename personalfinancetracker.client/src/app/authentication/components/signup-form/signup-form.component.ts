import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserRegistrationService } from '../../services/user-registration/user-registration.service';
import { Router } from '@angular/router';
import { JwtService } from '../../services/jwt/jwt.service';
import { of } from 'rxjs';

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
        private _formBuilder: FormBuilder,
        private _router: Router,
        private _jwtService: JwtService,
        private _userRegistrationService: UserRegistrationService)
    {
        this.signupForm = this._formBuilder.group({
            username: "",
            email: "",
            password: "",
        })
    }

    public submitSignupForm() {
        this._userRegistrationService
            .registerUser(this.signupForm.value)
            .subscribe({
                error: console.error,
                next: (res) => this.submitSignupFormNext(res as SubmitSignupFormResponse),
            })
    }

    public submitSignupFormNext({ token }: SubmitSignupFormResponse) {
        this._jwtService.token = token
        this._router.navigateByUrl("/dashboard")
    }

    public handleLoginButtonClick() {
        this.toggleForms.emit()
    }
}
