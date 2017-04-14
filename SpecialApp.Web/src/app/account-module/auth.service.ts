import { Injectable } from '@angular/core';
import { IRegisterCustomer } from '../model/account-models';
import { ApiClientService } from '../core-module/api-client.service';

@Injectable()
export class AuthService {

    constructor(private apiClient: ApiClientService) { }

    createUser(model: IRegisterCustomer, password: string) {
        model.Password = password;
        let data = this.apiClient.post("UserAccount", model).subscribe();
    }

    getModel() {
        let data: string;
        this.apiClient.get("UserAccount/1").subscribe();
        let fff = data;
    }
}
