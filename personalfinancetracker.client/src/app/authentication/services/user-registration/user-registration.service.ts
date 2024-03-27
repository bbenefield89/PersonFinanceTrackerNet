import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserRegistrationService {
    private _apiUrl = "https://localhost:7178/api/users/register"

  constructor(private http: HttpClient) { }

    public registerUser(userData: any) {
        return this.http.post(this._apiUrl, userData);
    }

    public get apiUrl() {
        return this._apiUrl
    }
}
