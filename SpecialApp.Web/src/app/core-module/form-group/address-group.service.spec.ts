import { TestBed, inject } from '@angular/core/testing';

import { AddressGroupService } from './address-group.service';

describe('AddressGroupService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AddressGroupService]
    });
  });

  it('should ...', inject([AddressGroupService], (service: AddressGroupService) => {
    expect(service).toBeTruthy();
  }));
});
