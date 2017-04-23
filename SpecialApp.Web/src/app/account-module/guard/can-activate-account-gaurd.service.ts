import { Injectable } from '@angular/core';
import {
    CanActivate,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import { MainCoreService } from '../../core-module/main-core.service';

@Injectable()
export class CanActivateAccountGaurdService implements CanActivate {
    constructor(
        private mainCoreService: MainCoreService,
        private router: Router
    ) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.mainCoreService.hasLoggedIn === true) {
            this.router.navigate(
                [
                    this.mainCoreService.StorageService.getItem(
                        this.mainCoreService.MainConstantService.commonVariable.previous_url
                    )
                ]);
            return false;
        }
        return true;
    }
}