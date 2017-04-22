import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AccountRouterModule, routedComponents } from './account-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from '../core-module/core.module';
import { CustomerAccountService } from './customer-account.service';
import { AuthService } from './auth.service';
import { CanActivateAccountGaurdService } from './guard/can-activate-account-gaurd.service';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        BrowserAnimationsModule,
        MaterialModule,
        FlexLayoutModule,
        AccountRouterModule,
        CoreModule
    ],
    providers: [CanActivateAccountGaurdService,
        { provide: 'Window', useValue: window }, CustomerAccountService, AuthService],
    declarations: [routedComponents]
})
export class AccountModule { }


/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/