import { TestBed, inject } from '@angular/core/testing';

import { CanActivateAccountGaurdService } from './can-activate-account-gaurd.service';

describe('CanActivateAccountGaurdService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CanActivateAccountGaurdService]
    });
  });

  it('should ...', inject([CanActivateAccountGaurdService], (service: CanActivateAccountGaurdService) => {
    expect(service).toBeTruthy();
  }));
});
