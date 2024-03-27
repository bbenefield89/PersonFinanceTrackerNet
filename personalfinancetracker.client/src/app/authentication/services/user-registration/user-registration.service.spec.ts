import { TestBed } from '@angular/core/testing';

import { UserRegistrationService } from './user-registration.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('UserRegistrationService', () => {
  let service: UserRegistrationService;

  beforeEach(() => {
      TestBed.configureTestingModule({
          imports: [
              HttpClientTestingModule
          ]
      });
    service = TestBed.inject(UserRegistrationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
