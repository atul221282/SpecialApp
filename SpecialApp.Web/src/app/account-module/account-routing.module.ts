import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { AccountComponent, LoginComponent, ForgotPasswordComponent } from './';

import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './password/forgot-password.component';
import { RegisterCustomerComponent } from './register-customer/register-customer.component';
import { CanActivateUnAuthGuardService } from '../core-module/guard/can-activate-unauth-guard.service';

const routes: Routes = [
    {
        path: 'account',
        component: AccountComponent,
        canActivate: [CanActivateUnAuthGuardService],
        children: [
            { path: 'login', component: LoginComponent },
            { path: 'forgot-password', component: ForgotPasswordComponent },
            { path: 'add-customer', component: RegisterCustomerComponent },
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
    ForgotPasswordComponent,
    RegisterCustomerComponent
];

/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/