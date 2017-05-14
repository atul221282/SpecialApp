import { NgModule } from '@angular/core';
import { FranchiseRouterModule, routedComponents } from './franchise-routing.module';
import { CoreModule } from '../core-module/core.module';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FranchiseSpecialAccountService } from './';

@NgModule({
    imports: [
        CommonModule,
        FranchiseRouterModule,
        FlexLayoutModule,
        MaterialModule,
        FormsModule,
        ReactiveFormsModule,
        CoreModule
    ],
    providers: [FranchiseSpecialAccountService],
    declarations: [routedComponents]
})
export class FranchiseModule { }
