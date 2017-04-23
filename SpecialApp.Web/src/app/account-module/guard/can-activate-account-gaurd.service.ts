import { Injectable } from '@angular/core';
import {
    CanActivate,
    CanActivateChild,
    Route,
    Router,
    ActivatedRoute,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';

import { MainCoreService } from '../../core-module/main-core.service';

@Injectable()
export class CanActivateAccountGaurdService implements CanActivate {
    constructor(
        private mainCoreService: MainCoreService,
        private router: Router,
        private activatedRoute:ActivatedRoute,
    ) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.mainCoreService.hasLoggedIn === true) {
            let route = this.activatedRoute.snapshot.url;
            //console.log();
            this.router.navigate([localStorage.getItem('previousRoute')]);
            return false;
        }
        return true;
    }
}