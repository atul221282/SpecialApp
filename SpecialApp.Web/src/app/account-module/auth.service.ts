import { Injectable } from '@angular/core';
import { IRegisterCustomer } from '../model/account-models';
import { ApiClientService } from '../core-module/api-client.service';
import * as moment from 'moment';

@Injectable()
export class AuthService {

    constructor(private apiClient: ApiClientService) { }

    createUser(model: IRegisterCustomer, password: string) {
        let mom = moment(model.DateOfBirth);
        model = <IRegisterCustomer>{
            DateOfBirth: new Date(mom.format('DD/MM/YYYY')),
            EmailAddress: model.EmailAddress,
            FirstName: model.FirstName,
            LastName: model.LastName,
            Password: model.Password || password,
            PhoneNumber: model.PhoneNumber,
            UserName: model.UserName
        };
        let data = this.apiClient.post("UserAccount", model).subscribe();
    }

    getModel() {
        let data: string;
        this.apiClient.get("UserAccount/1").subscribe();
        let fff = data;
    }
}
