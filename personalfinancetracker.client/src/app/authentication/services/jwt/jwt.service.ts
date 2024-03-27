import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtService {
    private _token = "";

    constructor() { }

    public get token() {
        return this._token
    }

    public set token(token: string) {
        this._token = token
    }
}
