import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { AddressGroupService } from './address-group.service';
import { ConfirmPasswordService } from './confirm-password.service';
@Injectable()
export class FormGroupService {

    constructor(
        private _fb: FormBuilder,
        public addressGroup: AddressGroupService,
        public confirmPassword: ConfirmPasswordService
    ) { }

}
