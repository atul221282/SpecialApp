import { TestBed, inject } from '@angular/core/testing';

import { CanActivateSpecialGuard } from './can-activate-special-guard';

describe('CanActivateSpecialGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CanActivateSpecialGuard]
    });
  });

  it('should ...', inject([CanActivateSpecialGuard], (service: CanActivateSpecialGuard) => {
    expect(service).toBeTruthy();
  }));
});
