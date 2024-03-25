import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-signup-form',
  templateUrl: './signup-form.component.html',
  styleUrl: './signup-form.component.css'
})
export class SignupFormComponent {
    @Output() toggleForms = new EventEmitter<void>()
    public signupForm: FormGroup;

    constructor(private formBuilder: FormBuilder) {
        this.signupForm = formBuilder.group({
            username: "",
            email: "",
            password: "",
        })
    }

    handleLoginButtonClick() {
        this.toggleForms.emit()
    }
}
