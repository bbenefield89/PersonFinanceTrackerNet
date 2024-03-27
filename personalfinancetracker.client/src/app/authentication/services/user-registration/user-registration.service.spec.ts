import { TestBed } from '@angular/core/testing';

import { UserRegistrationService } from './user-registration.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';

describe('UserRegistrationService', () => {
    let service: UserRegistrationService;
    let http: HttpClient;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
            ]
        });
        service = TestBed.inject(UserRegistrationService);
        http = TestBed.inject(HttpClient)
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it("should make a post request when registering a new user", () => {
        const httpPostSpy = spyOn(http, "post")
        const userData = { username: "name", "email": "user@email.com", password: "secret" }

        service.registerUser(userData)
        expect(httpPostSpy).toHaveBeenCalledWith(service.apiUrl, userData)
    })
});
