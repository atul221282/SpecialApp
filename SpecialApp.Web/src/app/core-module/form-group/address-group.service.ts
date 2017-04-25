import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Injectable()
export class AddressGroupService {
    isStateRequired: boolean = true;
    addressStateRequiredError = 'Address state is required';
    constructor(private _fb: FormBuilder) { }

    get AddressStateError() {
        return {
            required: this.addressStateRequiredError
        };
    }

    overrideAddressState(required: boolean, requiredError: string) {
        this.addressStateRequiredError = requiredError;
        this.isStateRequired = required;
    }

    getAddressGroup(): FormGroup {
        return this._fb.group({
            AddressState: ['', this.isStateRequired === true ? Validators.required : undefined]
        });
    }
}
