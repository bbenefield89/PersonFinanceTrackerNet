import { Component, OnInit } from '@angular/core';
import { JwtService } from '../../authentication/services/jwt/jwt.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrl: './dashboard-page.component.css'
})
export class DashboardPageComponent implements OnInit {

    constructor(
        private _router: Router,
        private _jwtService: JwtService,)
    {}

    ngOnInit() {
        if (!this._jwtService.token) {
            this._router.navigateByUrl("/")
        }
    }

}
