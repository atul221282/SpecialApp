import { TestBed, inject } from '@angular/core/testing';

import { FranchiseSpecialAccountService } from './franchise-special-account.service';

describe('FranchiseSpecialAccountService', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [FranchiseSpecialAccountService]
        });
    });

    it('should ...', inject([FranchiseSpecialAccountService], (service: FranchiseSpecialAccountService) => {
        expect(service).toBeTruthy();
    }));
});
