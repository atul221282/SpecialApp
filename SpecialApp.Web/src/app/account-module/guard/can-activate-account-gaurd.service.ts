import { Injectable } from '@angular/core';
import {
    CanActivate,
    CanActivateChild,
    Route,
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
            this.router.navigate(['/special'], { queryParams: { redirectTo: state.url } });
            return false;
        }
        return true;
    }
}