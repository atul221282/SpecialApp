import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { ApiClientService } from './api-client.service';
import { MainConstantService } from './main-constant.service';

@Injectable()
export class MainCoreService {

    constructor(
        public StorageService: StorageService,
        public ApiClientService: ApiClientService,
        public MainConstantService: MainConstantService
    ) { }

}
