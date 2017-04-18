import { Injectable } from '@angular/core';
import { ApiClientService, StorageService } from '../core-module/index';
import { ILoginModel } from '../model/account-models';

@Injectable()
export class AuthService {
    public baseUrl: string = "/account";
    constructor(private apiService: ApiClientService, private storageService: StorageService) { }

    login(model: ILoginModel) {
        return this.apiService.post(`${this.baseUrl}/Auth`, model)
            .subscribe(response=>this.storageService.setItem("access-token",response));
    }
}
