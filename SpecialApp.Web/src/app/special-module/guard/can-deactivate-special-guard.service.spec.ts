import { TestBed, inject } from '@angular/core/testing';

import { CanDeactivateSpecialGuardService } from './can-deactivate-special-guard.service';

describe('CanDeactivateSpecialGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CanDeactivateSpecialGuardService]
    });
  });

  it('should ...', inject([CanDeactivateSpecialGuardService], (service: CanDeactivateSpecialGuardService) => {
    expect(service).toBeTruthy();
  }));
});
