import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CoreUserMenuComponent } from './core-user-menu/core-user-menu.component';
import {
    LoadingSpinnerComponent, ToolbarComponent, LoginMenuComponent,
    MdInputComponent, FormControlInputComponent, FormAutoCompleteComponent, FormDateComponent,
    ApiClientService, StorageService, CoreListComponent
} from './';
import {FlexInputDirective } from './flex-form-input/flex-input.directive';
import { MainConstantService } from './main-constant.service';
import { MainCoreService } from './main-core.service';
import { CanActivateUnAuthGuardService } from './guard/can-activate-unauth-guard.service';
import { FormControlModule } from '../form-control-module/form-control.module';
import {FormSelectComponent } from './form-select/form-select.component';
import { CoreAutocompleteComponent} from './core-autocomplete/core-autocomplete.component';
@NgModule({
    imports: [
        CommonModule,
        MaterialModule,
        FlexLayoutModule,
        ReactiveFormsModule,
        FormsModule,
        FormControlModule
    ],
    declarations: [
        FormDateComponent,
        FormSelectComponent,
        FormAutoCompleteComponent,
        FormControlInputComponent,
        LoadingSpinnerComponent,
        LoginMenuComponent,
        ToolbarComponent,
        MdInputComponent,
        CoreUserMenuComponent,
        CoreListComponent,
        CoreAutocompleteComponent,
        FlexInputDirective
    ],
    exports: [
        FormDateComponent,
        FormSelectComponent,
        FormAutoCompleteComponent,
        FormControlInputComponent,
        LoadingSpinnerComponent,
        ToolbarComponent,
        MdInputComponent,
        CoreUserMenuComponent,
        CoreListComponent,
        CoreAutocompleteComponent,
        FlexInputDirective
    ],
    providers: [
        CanActivateUnAuthGuardService,
        StorageService,
        ApiClientService,
        MainConstantService,
        MainCoreService
    ]
})

export class CoreModule { }