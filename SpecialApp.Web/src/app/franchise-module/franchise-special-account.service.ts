import { Injectable } from '@angular/core';
import { ApiClientService } from '../core-module/';
import { State } from '../model/';

@Injectable()
export class FranchiseSpecialAccountService {

    constructor(private apiClient: ApiClientService) { }

    create(franchiseAccountModel: any) {
        franchiseAccountModel['State'] = State.Added;
        this.apiClient.post('account/franchise', franchiseAccountModel).subscribe();
    }
}
