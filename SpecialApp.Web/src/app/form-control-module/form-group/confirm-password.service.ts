import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { ConfirmPasswordValidator } from '../../core-module/';

@Injectable()
export class ConfirmPasswordService {

    constructor(private _fb: FormBuilder) { }

    errorMessage = {
        required: 'Confirm password is required',
        match: ConfirmPasswordValidator.confirmPasswordMessage('Password and confirm password do not match')
    };

    getFormGroup() {
        return this._fb.group({
            Password: ['Cloudno9!', Validators.required],
            ConfirmPassword: ['Cloudno9!', Validators.required],
        }, { validator: ConfirmPasswordValidator.passwordMatcher('Password', 'ConfirmPassword') });
    }
}
