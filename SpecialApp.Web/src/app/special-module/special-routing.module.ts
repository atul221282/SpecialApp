import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanActivateSpecialGuard } from './guard/can-activate-special-guard';
import { SpecialComponent } from './special.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [
    // { path: '', pathMatch: 'full', redirectTo: '/characters' },
    {
        path: '',
        component: SpecialComponent,
        canActivate: [CanActivateSpecialGuard],
        children: [
            { path: '', component: ListComponent }
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
    ListComponent
];

/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/