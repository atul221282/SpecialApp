import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { MainCoreService } from '../core-module/main-core.service';
import { Http } from "@angular/http";

@Injectable()
export class SpecialService {
    private baseUrl: string = "http://localhost:54187/api/Special";
    constructor(private mainCore: MainCoreService, private http: Http) { }

    getUserLocation() {
        return this.mainCore.MainConstantService.getCurrentLocation();

    }

    getByLocation(data: Position) {
        const coords = data.coords;
        // Special
        return this.http.get(`${this.baseUrl}?latitude=${coords.latitude}
                        &longitude=${coords.longitude}&accuracy=${coords.accuracy}`).map(data => {
                return data.json();
            }).catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error);
    }
}
