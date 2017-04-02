import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingSpinnerComponent, ApiClientService, ToolbarComponent, LoginMenuComponent } from './';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
    imports: [
        MaterialModule,
        FlexLayoutModule
    ],
    declarations: [
        LoadingSpinnerComponent,
        LoginMenuComponent,
        ToolbarComponent
    ],
    exports: [
        LoadingSpinnerComponent,
        ToolbarComponent
    ],
    providers: [
        ApiClientService
    ]
})
export class CoreModule { }