import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';

@Injectable()
export class MainCoreService {

    constructor(
        public StorageService: StorageService
    ) { }

}
