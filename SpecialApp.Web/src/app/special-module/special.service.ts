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
        const queryParams = new URLSearchParams();
        queryParams.set('Accuracy', data.coords.accuracy.toString());
        queryParams.set('Latitude', data.coords.latitude.toString());
        queryParams.set('Longitude', data.coords.longitude.toString());

        // Special
        return this.http.get(`${this.baseUrl}`,
            { params: queryParams }).map(data => {
                return data;
            }).catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error);
    }
}
