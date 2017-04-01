import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AccountRouterModule, routedComponents } from './account-routing.module';

@NgModule({
    imports: [CommonModule, FormsModule, AccountRouterModule],
    declarations: [routedComponents],
    providers: [],
})
export class AccountModule { }


/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/