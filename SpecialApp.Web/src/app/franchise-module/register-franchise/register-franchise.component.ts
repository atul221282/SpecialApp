import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator } from '../../core-module/';

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

    constructor(private _fb: FormBuilder) { }

    ngOnInit() {
        this.registerFranchiseForm = this._fb.group({
            Name: [{ value: 'Woolies', disabled: false }, [
                Validators.required
            ]]
        });
    }

}
