import { Injectable, Injector } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { StorageService } from './storage.service';
import { MainConstantService } from './main-constant.service';
import { IToken } from '../model/account-models';

@Injectable()
export class ApiClientService {
    apiUrl: string = "http://localhost:54187/api/";
    constructor(
        private http: Http,
        private storageService: StorageService,
        private mainConstantService: MainConstantService
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
        let token = this.storageService.getItem<IToken>(this.mainConstantService.commonVariable.access_token);

        if (token && token !== null)
            return `bearer ${token.token}`;

        return undefined;
    }

    //getDocument<T>(url: string, showSpinner?: boolean, params?: { [name: string]: any; }, authorize?: boolean, config?: angular.IRequestShortcutConfig) {
    //    if (config && config !== null) {
    //        config["responseType"] = "arraybuffer";
    //    }
    //    else {
    //        config = {
    //            responseType: "arraybuffer",
    //        }
    //    }
    //    return this.get<T>(url, showSpinner, params, authorize, config);
    //}

    //getAndViewPDFDocument(filenameWithExtension: string, url: string, showSpinner?: boolean, params?: { [name: string]: any; }, authorize?: boolean, config?: angular.IRequestShortcutConfig) {
    //    let deferred: ng.IDeferred<{}> = this.$q.defer();
    //    if (showSpinner === true)
    //        this.dialogService.showSpinner();
    //    this.getDocument(url, showSpinner, params, authorize, config).then((response: any) => {


    //        var ieEDGE = navigator.userAgent.match(/Edge/g);
    //        var ie = navigator.userAgent.match(/.NET/g); // IE 11+
    //        var oldIE = navigator.userAgent.match(/MSIE/g);

    //        var blob = new Blob([response.data], { type: 'application/pdf' });
    //        if (ie || oldIE || ieEDGE) {
    //            window.navigator.msSaveOrOpenBlob(blob, filenameWithExtension);
    //            deferred.resolve(response);
    //        }
    //        else {
    //            var file = new Blob([response.data], { type: 'application/pdf' });
    //            var fileURL = URL.createObjectURL(file);
    //            var win = window.open("", "_blank");
    //            win.document.write(`<iframe src="${fileURL}" 
    //                                            style="position:fixed; top:0px; left:0px; bottom:0px; right:0px; width:100%; height:100%; border:none; 
    //                                            margin:0; padding:0; overflow:hidden; z-index:999999;"
    //                                            frameborder="0" allowfullscreen></iframe>`);
    //            this.dialogService.hideSpinner();
    //            deferred.resolve(response);
    //        }
    //    }, (error) => {
    //        this.dialogService.hideSpinner();
    //        deferred.reject(error.data)
    //    });
    //    return deferred.promise;
    //}

    //uploadFile<T>(url: string, file: any, showSpinner?: boolean, authorize?: boolean, config?: angular.IRequestShortcutConfig) {

    //    if (config && config !== null) {
    //        config["transformRequest"] = angular.identity;
    //        config["headers"] = {
    //            'Content-Type': undefined
    //        }
    //    }
    //    else {
    //        config = {
    //            transformRequest: angular.identity,
    //            headers: {
    //                'Content-Type': undefined
    //            }
    //        }
    //    }
    //    var fd = new FormData();
    //    fd.append('file', file);

    //    return this.post<T>(url, fd, showSpinner, authorize, config);
    //}

    //uploadFileWithData<T>(url: string, file: any, data: any, showSpinner?: boolean, authorize?: boolean, config?: angular.IRequestShortcutConfig) {

    //    if (config && config !== null) {
    //        config["transformRequest"] = angular.identity;
    //        config["headers"] = {
    //            'Content-Type': undefined
    //        }
    //    }
    //    else {
    //        config = {
    //            transformRequest: angular.identity,
    //            headers: {
    //                'Content-Type': undefined
    //            }
    //        }
    //    }
    //    var fd = new FormData();
    //    fd.append('file', file);

    //    for (var key in data) {
    //        if (data.hasOwnProperty(key)) {
    //            fd.append(key, data[key]);
    //        }
    //    }
    //    return this.post<T>(url, fd, showSpinner, authorize, config);
    //}
}