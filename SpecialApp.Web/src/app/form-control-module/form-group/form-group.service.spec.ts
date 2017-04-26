import { TestBed, inject } from '@angular/core/testing';

import { FormGroupService } from './form-group.service';

describe('FormGroupService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FormGroupService]
    });
  });

  it('should ...', inject([FormGroupService], (service: FormGroupService) => {
    expect(service).toBeTruthy();
  }));
});
