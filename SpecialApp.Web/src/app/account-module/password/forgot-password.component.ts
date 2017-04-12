import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';

@Component({
    selector: 'forgot-password',
    templateUrl: './forgot-password.component.html',
    styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
    public forgotPasswordForm: FormGroup;
    public emailErrors = {
        required: "Email address is required",
        minlength: "Emaill address can't be less than 5 characters",
        maxlength: "Emaill address can't be greater than 50 characters",
        email: "Invalid email"
    }
    constructor(private _fb: FormBuilder) { }

    ngOnInit() {
        this.forgotPasswordForm = this._fb.group({
            EmailAddress: [{ value: '', disabled: false }, [
                Validators.required,
                Validators.minLength(5),
                Validators.maxLength(50),
            ]]
        });
    }
}