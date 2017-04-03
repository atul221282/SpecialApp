import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { AccountComponent, LoginComponent, ForgotPasswordComponent } from './';

import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './password/forgot-password.component';

const routes: Routes = [
    // { path: '', pathMatch: 'full', redirectTo: '/characters' },
    {
        path: 'account',
        component: AccountComponent,
        children: [
            { path: 'login', component: LoginComponent },
            { path: 'forgot-password', component: ForgotPasswordComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AccountRouterModule { }

export const routedComponents = [
    AccountComponent,
    LoginComponent,
    ForgotPasswordComponent
];

/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/