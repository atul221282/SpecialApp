import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { ApiClientService } from './api-client.service';

@Injectable()
export class MainCoreService {

    constructor(
        public StorageService: StorageService,
        public ApiClientService: ApiClientService
    ) { }

}
