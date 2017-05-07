import { TestBed, inject } from '@angular/core/testing';

import { CompanyAccountService } from './company-account.service';

describe('CompanyAccountService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CompanyAccountService]
    });
  });

  it('should ...', inject([CompanyAccountService], (service: CompanyAccountService) => {
    expect(service).toBeTruthy();
  }));
});
