import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import {
    LoadingSpinnerComponent, ToolbarComponent, LoginMenuComponent,
    MdInputComponent, FormControlInputComponent, FormSelectComponent, FormDateComponent,
    ApiClientService,
    StorageService
} from './';
import { MainConstantService } from './main-constant.service';
import { MainCoreService } from './main-core.service';

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
        StorageService,
        ApiClientService,
        MainConstantService,
        MainCoreService
    ]
})
export class CoreModule { }