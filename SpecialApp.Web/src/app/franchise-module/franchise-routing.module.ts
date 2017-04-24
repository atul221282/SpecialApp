import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FranchiseComponent } from './franchise/franchise.component';
import { RegisterFranchiseComponent } from './register-franchise/register-franchise.component';
import { CanActivateUnAuthGuardService } from '../core-module/guard/can-activate-unauth-guard.service';

const routes: Routes = [
    {
        path: '',
        component: FranchiseComponent,
        children: [
            {
                path: 'register', component: RegisterFranchiseComponent, canActivate: [CanActivateUnAuthGuardService]
            },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class FranchiseRouterModule { }

export const routedComponents = [
    FranchiseComponent,
    RegisterFranchiseComponent
];

/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/