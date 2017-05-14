import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray } from '@angular/forms';
import { EmailValidator } from '../../core-module/';
import { FormGroupService } from '../../form-control-module/form-group/form-group.service';
import { Router } from '@angular/router'

@Component({
    selector: 'register-franchise',
    templateUrl: './register-franchise.component.html',
    styleUrls: ['./register-franchise.component.css']
})
export class RegisterFranchiseComponent implements OnInit {

    registerFranchiseForm: FormGroup;

    get Addresses(): FormArray {
        return <FormArray>this.registerFranchiseForm.get('Addresses');
    }

    name = {
        required: "Franchise name is required"
    }

    companyFranchiseCategoryError = {
        required: "CompanyFranchiseCategory is required"
    }

    AddressType = "AddressType";

    constructor(
        private _fb: FormBuilder,
        private formGroupService: FormGroupService,
        private router: Router
    ) {
    }

    ngOnInit() {
        this.formGroupService.addressGroup.isStateRequired = true;

        this.registerFranchiseForm = this._fb.group({
            CompanyId: [{ value: null, disabled: false }, [
                Validators.required
            ]],
            CompanyFranchiseCategoryId: [null, Validators.required],
            Addresses: this._fb.array([
                this.buildAddress()
            ]),
            IsConfirmed: [false, Validators.required],
            CanGetCustomerDetails: [false, Validators.required],
            CanContactCustomers: [false, Validators.required],
            CanSellOnline: [false, Validators.required],
        });
    }

    buildAddress(): FormGroup {
        return this.formGroupService.addressGroup.getAddressGroup;
    }

    addAddress(): void {
        this.Addresses.push(this.buildAddress());
    }

    submit() {
        console.log(this.registerFranchiseForm.getRawValue());
    }

    cancel() {
        this.registerFranchiseForm.reset();
    }

    AddCompany() {
        this.router.navigate(['company/create']);
    }
}
