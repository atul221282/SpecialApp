import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'account-register-customer',
    templateUrl: './register-customer.component.html',
    styleUrls: ['./register-customer.component.scss']
})
export class RegisterCustomerComponent implements OnInit {
    public registerForm: FormGroup;

    public emailErrors = {
        required: "Email address is required",
        minlength: "Emaill address can't be less than 5 characters",
        maxlength:"Emaill address can't be greater than 3 characters"
    }

    constructor(private _fb: FormBuilder) { }
    ngOnInit() {
        this.registerForm = this._fb.group({
            EmailAddress: [{ value: 'atul', disabled: false }, [Validators.required, Validators.minLength(5), Validators.maxLength(3)]],
            FirstName: '',
            LastName: ''
        });
    }

    submit(data: any) {
        alert(JSON.stringify(this.registerForm.getRawValue()));
    }
}
