import { TestBed, inject } from '@angular/core/testing';

import { LoginMenuService } from './login-menu.service';

describe('LoginMenuService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LoginMenuService]
    });
  });

  it('should ...', inject([LoginMenuService], (service: LoginMenuService) => {
    expect(service).toBeTruthy();
  }));
});
