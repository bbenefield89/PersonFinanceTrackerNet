import { Component } from '@angular/core';

@Component({
  selector: 'app-signup-login-page',
  templateUrl: './signup-login-page.component.html',
  styleUrl: './signup-login-page.component.css'
})
export class SignupLoginPageComponent {
    public showLoginForm = false;

    toggleForms() {
        this.showLoginForm = !this.showLoginForm
    }
}
