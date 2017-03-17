import { TestBed, inject } from '@angular/core/testing';

import { ApiClientService } from '../../src/app';

describe('ApiClientService', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [ApiClientService]
        });
    });

    it('should ...', inject([ApiClientService], (service: ApiClientService) => {
        expect(service).toBeTruthy();
        expect(service.apiUrl).toBeDefined();
    }));
});
