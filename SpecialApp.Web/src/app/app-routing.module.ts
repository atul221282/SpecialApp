import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from './page-not-found.component';

const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: '/account/login' },
    { path: 'special', loadChildren: 'app/special-module/special.module#SpecialModule' },
    { path: 'franchise', loadChildren: 'app/franchise-module/franchise.module#FranchiseModule' },
    //{ path: 'special', pathMatch: 'full', redirectTo: '/special' },
    { path: '**', pathMatch: 'full', component: PageNotFoundComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

export const routableComponents = [PageNotFoundComponent];


/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/