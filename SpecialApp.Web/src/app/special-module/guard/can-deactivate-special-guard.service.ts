import { Injectable } from '@angular/core';
import {
    CanDeactivate,
    Route,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { SpecialAddComponent} from '../special-add/special-add.component';

@Injectable()
export class CanDeactivateSpecialGuardService implements CanDeactivate<SpecialAddComponent> {

    constructor(private router: Router) { }

    canDeactivate(
        component: SpecialAddComponent,
        currentRoute: ActivatedRouteSnapshot,
        currentState: RouterStateSnapshot,
        nextState: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {
        return true;
    }
}
