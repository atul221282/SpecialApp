import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { FormGroupService } from '../../form-control-module/form-group/form-group.service';

@Component({
    selector: 'app-company-register',
    templateUrl: './company-register.component.html',
    styleUrls: ['./company-register.component.css']
})

export class CompanyRegisterComponent implements OnInit {
    createCompany: FormGroup;
    companyNameErrors = {
        required: "Company name is required"
    }
    detailsErrors = {
        required: "Company Details are required"
    }
    constructor(
        private _fb: FormBuilder,
        private formGroupService: FormGroupService
    ) { }

    ngOnInit() {
        this.createCompany = this._fb.group({
            CompanyName: [{ value: '', disabled: false }, [
                Validators.required
            ]],
            NumberOfEmployees: [{
                value: null
                , disabled: false
            }, [
            ]],
            Details: [{ value: '', disabled: false }, [
                Validators.required
            ]],
            AddressGroup: this.formGroupService.addressGroup.getAddressGroup(),
        });
    }

    submit() {
        alert(JSON.stringify(this.createCompany.getRawValue()));
    }

    cancel() {
        this.createCompany.reset();
    }
}
