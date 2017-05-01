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
    companyFranchiseCategoryError = {
        required: "CompanyFranchiseCategory is required"
    }

    AddressType = "AddressType2";

    constructor(
        private _fb: FormBuilder,
        private formGroupService: FormGroupService
    ) {
    }

    ngOnInit() {
        this.formGroupService.addressGroup.isStateRequired = true;

        setTimeout(() => {
            this.AddressType = "AddressType";
        }, 9999)

        this.registerFranchiseForm = this._fb.group({
            CompanyId: [{ value: null, disabled: false }, [
                Validators.required
            ]],
            CompanyFranchiseCategoryId: [null, Validators.required],
            AddressGroup: this.formGroupService.addressGroup.getAddressGroup(),
            IsConfirmed: [false, Validators.required],
            CanGetCustomerDetails: [false, Validators.required],
            CanContactCustomers: [false, Validators.required],
            CanSellOnline: [false, Validators.required],
        });
    }

    submit() {
        console.log(this.registerFranchiseForm.getRawValue());
    }

    cancel() {
        this.registerFranchiseForm.reset();
    }
}
