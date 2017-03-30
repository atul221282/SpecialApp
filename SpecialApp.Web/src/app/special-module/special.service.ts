import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class SpecialService {
    constructor() { }

    get<T>(): Observable<T> {
        return null;
    }
}