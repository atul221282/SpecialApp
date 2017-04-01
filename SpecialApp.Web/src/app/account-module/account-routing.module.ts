import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent, LoginComponent, ForgotPasswordComponent } from './';

const routes: Routes = [
    // { path: '', pathMatch: 'full', redirectTo: '/characters' },
    {
        path: 'account',
        component: AccountComponent,
        children: [
            { path: '', component: LoginComponent },
            { path: ':id', component: ForgotPasswordComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AccountRouterModule { }

export const routedComponents = [
    LoginComponent,
    ForgotPasswordComponent
];


/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/