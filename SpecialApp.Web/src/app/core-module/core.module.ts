import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LoadingSpinnerComponent, ApiClientService, ToolbarComponent, LoginMenuComponent, MdInputComponent } from './';


@NgModule({
    imports: [
        CommonModule,
        MaterialModule,
        FlexLayoutModule,
        FormsModule
    ],
    declarations: [
        LoadingSpinnerComponent,
        LoginMenuComponent,
        ToolbarComponent,
        MdInputComponent
    ],
    exports: [
        LoadingSpinnerComponent,
        ToolbarComponent,
        MdInputComponent
    ],
    providers: [
        ApiClientService
    ]
})
export class CoreModule { }