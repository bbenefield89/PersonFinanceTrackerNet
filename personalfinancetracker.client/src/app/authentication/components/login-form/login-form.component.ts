import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent {
    @Output() toggleForms = new EventEmitter<void>()

    public handleLoginButtonClick() {
        console.log("Form submitted")
    }

    public handleSignupButtonClick() {
        this.toggleForms.emit()
    }
}
