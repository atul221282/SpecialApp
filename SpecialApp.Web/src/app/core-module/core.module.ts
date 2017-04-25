import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CoreUserMenuComponent } from './core-user-menu/core-user-menu.component';
import {
    LoadingSpinnerComponent, ToolbarComponent, LoginMenuComponent,
    MdInputComponent, FormControlInputComponent, FormSelectComponent, FormDateComponent,
    ApiClientService,
    StorageService
} from './';
import { MainConstantService } from './main-constant.service';
import { MainCoreService } from './main-core.service';
import { CanActivateUnAuthGuardService } from './guard/can-activate-unauth-guard.service';
import { FormGroupService } from './form-group/form-group.service';
import { AddressGroupService } from './form-group/address-group.service';
import { ConfirmPasswordService} from './form-group/confirm-password.service';
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
        MdInputComponent,
        CoreUserMenuComponent
    ],
    exports: [
        FormDateComponent,
        FormSelectComponent,
        FormControlInputComponent,
        LoadingSpinnerComponent,
        ToolbarComponent,
        MdInputComponent,
        CoreUserMenuComponent
    ],
    providers: [
        ConfirmPasswordService,
        AddressGroupService,
        CanActivateUnAuthGuardService,
        FormGroupService,
        StorageService,
        ApiClientService,
        MainConstantService,
        MainCoreService
    ]
})

export class CoreModule { }