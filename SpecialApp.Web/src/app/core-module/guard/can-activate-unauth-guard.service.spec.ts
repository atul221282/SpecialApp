import { TestBed, inject } from '@angular/core/testing';

import { CanActivateUnAuthGuardService } from './can-activate-unauth-guard.service';

describe('CanActivateUnAuthGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CanActivateUnAuthGuardService]
    });
  });

  it('should ...', inject([CanActivateUnAuthGuardService], (service: CanActivateUnAuthGuardService) => {
    expect(service).toBeTruthy();
  }));
});
