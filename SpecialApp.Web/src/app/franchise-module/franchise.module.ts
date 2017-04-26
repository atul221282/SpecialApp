import { NgModule } from '@angular/core';
import { FranchiseRouterModule, routedComponents } from './franchise-routing.module';
import { CoreModule } from '../core-module/core.module';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';


@NgModule({
    imports: [
        CommonModule,
        FranchiseRouterModule,
        FlexLayoutModule,
        MaterialModule,
        CoreModule
    ],
    providers: [{ provide: 'Window', useValue: window }],
    declarations: [routedComponents]
})
export class FranchiseModule { }
