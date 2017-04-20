import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import {
    LoadingSpinnerComponent, ApiClientService, ToolbarComponent, LoginMenuComponent,
    MdInputComponent, FormControlInputComponent, FormSelectComponent, FormDateComponent, StorageService,
    LoginMenuService
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
        FormDateComponent,
        FormSelectComponent,
        FormControlInputComponent,
        LoadingSpinnerComponent,
        LoginMenuComponent,
        ToolbarComponent,
        MdInputComponent
    ],
    exports: [
        FormDateComponent,
        FormSelectComponent,
        FormControlInputComponent,
        LoadingSpinnerComponent,
        ToolbarComponent,
        MdInputComponent
    ],
    providers: [
        LoginMenuService,
        StorageService,
        ApiClientService
    ]
})
export class CoreModule { }