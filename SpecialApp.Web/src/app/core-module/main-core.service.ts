import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { ApiClientService } from './api-client.service';
import { MainConstantService } from './main-constant.service';

@Injectable()
export class MainCoreService {

    get hasLoggedIn(): boolean {
        return this.StorageService.getItem(this.MainConstantService.commonVariable.access_token) !== null;
    }

    constructor(
        public StorageService: StorageService,
        public ApiClientService: ApiClientService,
        public MainConstantService: MainConstantService
    ) { }

}
