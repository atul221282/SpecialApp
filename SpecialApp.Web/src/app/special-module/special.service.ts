import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { MainCoreService } from '../core-module/main-core.service';

@Injectable()
export class SpecialService {
    private baseUrl: string = "Special";
    constructor(private mainCore: MainCoreService) { }

    getByLocation() {
        // Special
        return this.mainCore.ApiClientService.get(`${this.baseUrl}/122`).map(data => {
            return data;
        }).catch(this.handleError);;
    }

    private handleError(error: Response) {
        let msg = `Error status code ${error.status} at ${error.url}`;
        return Observable.throw(error);
    }
}
