import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanActivateSpecialGuard } from './guard/can-activate-special-guard';
import { SpecialComponent } from './special.component';
import { SpecialListComponent } from './special-list/special-list.component';
import { SpecialEditComponent } from './special-edit/special-edit.component';
import { SpecialAddComponent } from './special-add/special-add.component';

const routes: Routes = [
    // { path: '', pathMatch: 'full', redirectTo: '/characters' },
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