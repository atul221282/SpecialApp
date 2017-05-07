import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';


@Injectable()
export class AddressGroupService {
    required: string = 'is required';

    isStateRequired: boolean = false;
    addressStateRequiredError = `Address state ${this.required}`;

    isPostCodeRequired: boolean = true;
    postCodeRequiredError = `Postcode ${this.required}`;

    isAddressTypeRequired: boolean = true;
    addressTypeRequiredError = `Address type ${this.required}`;

    constructor(private _fb: FormBuilder) { }

    get AddressStateError() {
        return {
            required: this.addressStateRequiredError
        };
    }

    get PostCodeError() {
        return {
            required: this.postCodeRequiredError
        }
    }

    get AddressTypeError() {
        return {
            required: this.addressTypeRequiredError
        }
    }

    overrideAddressState(required: boolean, requiredError: string) {
        this.addressStateRequiredError = requiredError;
        this.isStateRequired = required;
    }

    get getAddressGroup(): FormGroup {
        return this._fb.group({
            AddressState: ['', this.isStateRequired === true ? Validators.required : undefined],
            PostCode: ['', this.isPostCodeRequired === true ? Validators.required : undefined],
            AddressTypeId: [null, this.isAddressTypeRequired === true ? Validators.required : undefined]
        });
    }
}
