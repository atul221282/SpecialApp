import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyComponent } from './company.component';
import { CompanyRegisterComponent } from './company-register/company-register.component';

const routes: Routes = [
    {
        path: '',
        component: CompanyComponent,
        children: [
            { path: 'create', component: CompanyRegisterComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class CompanyRouterModule { }

export const routedComponents = [
    CompanyComponent,
    CompanyRegisterComponent
];

/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/