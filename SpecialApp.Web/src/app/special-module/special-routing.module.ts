import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanActivateSpecialGuard } from './guard/can-activate-special-guard';
import { SpecialComponent } from './special.component';
import { SpecialListComponent, SpecialEditComponent, SpecialAddComponent } from './';

const routes: Routes = [
    {
        path: '',
        component: SpecialComponent,
        canActivate: [CanActivateSpecialGuard],
        children: [
            { path: '', component: SpecialListComponent },
            { path: 'add', component: SpecialAddComponent },
            { path: 'detail/:id', component: SpecialListComponent }
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
    SpecialListComponent
];

/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/