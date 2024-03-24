import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
    public showMobileNavLinks = "";
    public navLinksData = [
        { href: "/", text: "Home" },
        { href: "/about", text: "About" },
        { href: "/services", text: "Services" },
        { href: "/contact", text: "Contact" },
    ]

    toggleNavLinks() {
        if (this.showMobileNavLinks) {
            this.showMobileNavLinks = "";
        }
        else {
            this.showMobileNavLinks = "show"
        }
    }
}
