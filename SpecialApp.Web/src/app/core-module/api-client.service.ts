﻿import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class ApiClientService {
    apiUrl: string = "http://localhost:54187/api/";
    constructor(private http: Http) { }

    test(message: string) {
        alert(`Message is ${message}`);
    }

    get<T>(url: string, options?: RequestOptionsArgs): Observable<T> {
        return this.http.get(`${this.apiUrl}${url}`)
            .map((res: Response) => {
                debugger;
                return res.json() as T;
            })
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
}