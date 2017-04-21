import { TestBed, inject } from '@angular/core/testing';

import { MainConstantService } from './main-constant.service';

describe('MainConstantService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MainConstantService]
    });
  });

  it('should ...', inject([MainConstantService], (service: MainConstantService) => {
    expect(service).toBeTruthy();
  }));
});
