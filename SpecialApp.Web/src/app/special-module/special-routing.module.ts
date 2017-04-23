import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanActivateSpecialGuard } from './guard/can-activate-special-guard';
import { SpecialComponent } from './special.component';
import { SpecialListComponent, SpecialEditComponent, SpecialAddComponent } from './';
import { CanDeactivateSpecialGuardService } from './guard/can-deactivate-special-guard.service';

const routes: Routes = [
    {
        path: '',
        component: SpecialComponent,
        canActivate: [CanActivateSpecialGuard],
        children: [
            { path: '', component: SpecialListComponent, canDeactivate: [CanDeactivateSpecialGuardService] },
            { path: 'add', component: SpecialAddComponent },
            { path: 'edit/:id', component: SpecialEditComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class SpecialRouterModule { }

export const routedComponents = [
    SpecialComponent,
    SpecialAddComponent,
    SpecialEditComponent,
    SpecialListComponent
];

/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/