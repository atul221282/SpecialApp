import { TestBed, inject } from '@angular/core/testing';

import { MainCoreService } from './main-core.service';

describe('MainCoreService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MainCoreService]
    });
  });

  it('should ...', inject([MainCoreService], (service: MainCoreService) => {
    expect(service).toBeTruthy();
  }));
});
