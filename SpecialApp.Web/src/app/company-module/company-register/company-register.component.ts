import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray } from '@angular/forms';
import { FormGroupService } from '../../form-control-module/form-group/form-group.service';

@Component({
    selector: 'app-company-register',
    templateUrl: './company-register.component.html',
    styleUrls: ['./company-register.component.css']
})

export class CompanyRegisterComponent implements OnInit {
    createCompanyForm: FormGroup;

    get addresses(): FormArray {
        return <FormArray>this.createCompanyForm.get('addresses');
    }

    constructor(
        private fb: FormBuilder,
        private formGroupService: FormGroupService
    ) { }

    ngOnInit() {
        this.createCompanyForm = this.fb.group({
            CompanyName: [{ value: '', disabled: false }, [
                Validators.required
            ]],
            NumberOfEmployees: [{
                value: null
                , disabled: false
            }, []
            ],
            Details: [{ value: '', disabled: false }, [
                Validators.required
            ]],
            addresses: this.fb.array([
                this.buildAddress()
            ])
        });

    }

    buildAddress(): FormGroup {
        return this.formGroupService.addressGroup.getAddressGroup;
    }

    submit() {
        alert(JSON.stringify(this.createCompanyForm.getRawValue()));
    }

    cancel() {
        this.createCompanyForm.reset();
    }
}
