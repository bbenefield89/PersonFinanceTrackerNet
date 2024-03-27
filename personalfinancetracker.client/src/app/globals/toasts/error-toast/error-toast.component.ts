import { Component } from '@angular/core';

@Component({
  selector: 'app-error-toast',
  templateUrl: './error-toast.component.html',
  styleUrl: './error-toast.component.css'
})
export class ErrorToastComponent {
    public retryAction() {
        console.log("Retry Action")
    }
}
