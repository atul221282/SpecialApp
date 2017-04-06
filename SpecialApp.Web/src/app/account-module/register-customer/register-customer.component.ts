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
        maxlength: "Emaill address can't be greater than 50 characters",
        email: "Invalid email"
    }
    public firstName = {
        required: "First name is required"
    }
    public lastName = {
        required: "Surname is required"
    }

    constructor(private _fb: FormBuilder) { }
    ngOnInit() {
        this.registerForm = this._fb.group({
            EmailAddress: [{ value: 'atul', disabled: false }, [
                Validators.required,
                Validators.minLength(5),
                Validators.maxLength(50),
            ]],
            FirstName: ['', Validators.required],
            LastName: ['', Validators.required]
        });
    }

    submit(data: any) {
        alert(JSON.stringify(this.registerForm.getRawValue()));
    }
}
