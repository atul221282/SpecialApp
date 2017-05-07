import { NgModule } from '@angular/core';
import { CompanyRouterModule, routedComponents } from './company-routing.module';
import { CoreModule } from '../core-module/core.module';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyAccountService } from './company-account.service';

@NgModule({
    imports: [
        CommonModule,
        CompanyRouterModule,
        FlexLayoutModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        CoreModule
    ],
    providers: [CompanyAccountService],
    declarations: [routedComponents]
})
export class CompanyModule { }
