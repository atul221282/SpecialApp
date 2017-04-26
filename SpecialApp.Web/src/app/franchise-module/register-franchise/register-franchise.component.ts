import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator } from '../../core-module/';
import { FormGroupService } from '../../form-control-module/form-group/form-group.service';

@Component({
    selector: 'register-franchise',
    templateUrl: './register-franchise.component.html',
    styleUrls: ['./register-franchise.component.css']
})
export class RegisterFranchiseComponent implements OnInit {

    registerFranchiseForm: FormGroup;
    name = {
        required: "Franchise name is required"
    }

    constructor(
        private _fb: FormBuilder,
        private formGroupService: FormGroupService
    ) {
        
    }

    ngOnInit() {
        this.formGroupService.addressGroup.isStateRequired = true;

        this.registerFranchiseForm = this._fb.group({
            CompanyId: [{ value: null, disabled: false }, [
                Validators.required
            ]],
            AddressGroup: this.formGroupService.addressGroup.getAddressGroup(),
            IsConfirmed: [{ value: false }, Validators.required],
            CanGetCustomerDetails: [{ value: false }, Validators.required],
            CanContactCustomers: [{ value: false }, Validators.required],
            CanSellOnline: [{ value: false }, Validators.required],
            CompanyFranchiseCategoryId: [{ value: null }, Validators.required],
        });
    }

}
