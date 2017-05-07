import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray } from '@angular/forms';
import { FormGroupService } from '../../form-control-module/form-group/form-group.service';
import { CompanyAccountService } from '../company-account.service';


@Component({
    selector: 'app-company-register',
    templateUrl: './company-register.component.html',
    styleUrls: ['./company-register.component.css']
})

export class CompanyRegisterComponent implements OnInit {
    createCompanyForm: FormGroup;

    get Addresses(): FormArray {
        return <FormArray>this.createCompanyForm.get('Addresses');
    }

    constructor(
        private fb: FormBuilder,
        private formGroupService: FormGroupService,
        private service: CompanyAccountService
    ) { }

    ngOnInit() {
        this.initFormGroup();
    }

    private initFormGroup() {
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
            Addresses: this.fb.array([
                this.buildAddress()
            ])
        });
    }

    buildAddress(): FormGroup {
        return this.formGroupService.addressGroup.getAddressGroup;
    }

    addAddress(): void {
        this.Addresses.push(this.buildAddress());
    }

    submit() {
        //alert(JSON.stringify(this.createCompanyForm.getRawValue()));
        this.service.createCompany(this.createCompanyForm.getRawValue())
            .subscribe((response) => {
                alert(response);
            }, (error) => {
                alert(error);
            })
    }

    cancel() {
        this.initFormGroup();
        this.createCompanyForm.reset();
    }
}
