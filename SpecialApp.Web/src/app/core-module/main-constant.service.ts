import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";

@Injectable()
export class MainConstantService {
    location: Coordinates;

    commonVariable = {
        access_token: "access_token",
        previous_url: "previousUrl"
    }
    constructor() { }

    getCurrentLocation(): Observable<Position> {
        return Observable.create(observer => {
            if (window.navigator && window.navigator.geolocation) {
                window.navigator.geolocation.getCurrentPosition(
                    (position) => {
                        observer.next(position);
                        observer.complete();
                    },
                    (error) => observer.error(error)
                );
            } else {
                observer.error('Unsupported Browser');
            }
        });
    }
}
