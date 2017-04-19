import { Injectable, Injector } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { StorageService } from './storage.service';
import { IToken } from '../model/account-models';

@Injectable()
export class ApiClientService {
    apiUrl: string = "http://localhost:54187/api/";
    constructor(
        private http: Http,
        private storageService: StorageService
    ) { }

    test(message: string) {
        alert(`Message is ${message}`);
    }

    get<T>(url: string, options?: RequestOptionsArgs): Observable<T> {
        return this.http.get(`${this.apiUrl}${url}`)
            .map((res: Response) => {
                return res.json() as T;
            }).catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    post<T>(url: string, data: any, options?: RequestOptionsArgs): Observable<T> {

        let headers = new Headers({
            'Authorization': this.accessToken
        });

        if (!options || options !== null)
            options = new RequestOptions({ headers: headers });

        return this.http.post(`${this.apiUrl}${url}`, data, options).map((res: Response) => {
            return res.json() as T;
        }).catch(this.handleError);
    }

    private handleError(error: Response | any) {
        // In a real world app, you might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
            return Observable.throw({ status: error.status, data: error.json() });
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw({ status: error.status, data: errMsg });
    }

    get accessToken(): string {
        let token = this.storageService.getItem<IToken>('access-token');

        if (token && token !== null)
            return `bearer ${token.token}`;

        return undefined;
    }
}