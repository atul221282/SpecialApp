import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';


@Injectable()
export class UserGroupService {
    required: string = 'is required';

    isFirstNameRequired: boolean = false;
    FirstNameRequiredError = `First name ${this.required}`;

    isLastNameRequired: boolean = false;
    LastNameRequiredError = `Last name ${this.required}`;
    //
    constructor(private _fb: FormBuilder) { }

    get userFormGroup(): FormGroup {
        return this._fb.group({
            FirstName: ['', this.isFirstNameRequired === true ? Validators.required : undefined],
            LastName: ['', this.isLastNameRequired === true ? Validators.required : undefined],
        });
    }
}
