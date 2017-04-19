import { Injectable } from '@angular/core';
import { IRegisterCustomer } from '../model/account-models';
import { ApiClientService } from '../core-module/api-client.service';
import * as moment from 'moment';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CustomerAccountService {

    public baseurl: string = "account/";

    constructor(private apiClient: ApiClientService) { }

    createUser(model: IRegisterCustomer, password: string) {
        model = <IRegisterCustomer>{
            DateOfBirth: model.DateOfBirth,
            EmailAddress: model.EmailAddress,
            FirstName: model.FirstName,
            LastName: model.LastName,
            Password: model.Password || password,
            PhoneNumber: model.PhoneNumber,
            UserName: model.UserName
        };
        return this.apiClient.post(`${this.baseurl}CustomerAccount`, model)
            .catch(this.handleError);
    }

    private handleError(error: Response, er: any) {
        let msg = `Error status code ${error.status} at ${error.url}`;
        return Observable.throw(msg);
    }
    getModel() {
        let data: string;
        this.apiClient.get("UserAccount/1").subscribe();
        let fff = data;
    }
}
