import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import {
    LoadingSpinnerComponent, ApiClientService, ToolbarComponent, LoginMenuComponent,
    MdInputComponent, FormControlInputComponent, FormSelectComponent
} from './';

@NgModule({
    imports: [
        CommonModule,
        MaterialModule,
        FlexLayoutModule,
        ReactiveFormsModule,
        FormsModule
    ],
    declarations: [
        FormSelectComponent,
        FormControlInputComponent,
        LoadingSpinnerComponent,
        LoginMenuComponent,
        ToolbarComponent,
        MdInputComponent
    ],
    exports: [
        FormSelectComponent,
        FormControlInputComponent,
        LoadingSpinnerComponent,
        ToolbarComponent,
        MdInputComponent
    ],
    providers: [
        ApiClientService
    ]
})
export class CoreModule { }