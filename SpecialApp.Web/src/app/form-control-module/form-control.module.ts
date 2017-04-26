import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressGroupService, ConfirmPasswordService, FormGroupService } from './form-group/';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule
    ],
    providers: [
        AddressGroupService, FormGroupService, ConfirmPasswordService
    ],
    declarations: []
})
export class FormControlModule { }
