import { Injectable } from '@angular/core';
import { ApiClientService, StorageService } from '../core-module/index';
import { ILoginModel, IToken } from '../model/account-models';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class AuthService {
    public baseUrl: string = "/account";
    constructor(private apiService: ApiClientService, private storageService: StorageService) { }

    login(model: ILoginModel) {
        return this.apiService.post(`${this.baseUrl}/Auth`, model)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        let msg = `Error status code ${error.status} at ${error.url}`;
        return Observable.throw(msg);
    }
}
