import { Injectable } from '@angular/core';
import { ApiClientService } from '../core-module/';

@Injectable()
export class FranchiseSpecialAccountService {

    constructor(private apiClient: ApiClientService) { }

    create(franchiseAccountModel:any) {
        this.apiClient.post('account/franchise', franchiseAccountModel).subscribe();
    }
}
