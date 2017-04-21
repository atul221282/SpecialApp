import { Injectable } from '@angular/core';
import { MainCoreService } from '../core-module/main-core.service';
import { ILoginModel, IToken } from '../model/account-models';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class AuthService {
    public baseUrl: string = "/account";
    constructor(private mainCoreService: MainCoreService) { }

    login(model: ILoginModel) {
        return this.mainCoreService.ApiClientService.post(`${this.baseUrl}/Auth`, model)
            .map(res => {
                this.mainCoreService.StorageService.setItem("access_token", res);
                return res;
            })
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        let msg = `Error status code ${error.status} at ${error.url}`;
        return Observable.throw(error);
    }
}
