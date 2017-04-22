import { Injectable } from '@angular/core';
import {
    CanActivate,
    Route,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import { MainCoreService } from '../../core-module/main-core.service';

@Injectable()
export class CanActivateSpecialGuard {

    constructor(
        private mainCoreService: MainCoreService,
        private router: Router
    ) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.mainCoreService.hasLoggedIn === true) {
            return true;
        }
        this.router.navigate(['/account/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }

}
