import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-signup-login-page',
  templateUrl: './signup-login-page.component.html',
  styleUrl: './signup-login-page.component.css'
})
export class SignupLoginPageComponent {
    public showSignupForm = true
    public showErrorToast = false

    public toggleForms() {
        this.showSignupForm = !this.showSignupForm
    }

    public toggleShowErrorToast() {
        this.showErrorToast = !this.showErrorToast
    }
}
