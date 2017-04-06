import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'account-register-customer',
    templateUrl: './register-customer.component.html',
    styleUrls: ['./register-customer.component.scss']
})
export class RegisterCustomerComponent implements OnInit {
    public registerForm: FormGroup;

    constructor(private _fb: FormBuilder) { }
    ngOnInit() {
        this.registerForm = this._fb.group({
            EmailAddress: [{ value: 'atul', disabled: false }, [Validators.required, Validators.minLength(5)]],
            FirstName: '',
            LastName: ''
        });
        this.registerForm.get('EmailAddress').valueChanges.subscribe(value => console.log(value));
    }

    submit(data: any) {
        alert(JSON.stringify(this.registerForm.getRawValue()));
    }
}
