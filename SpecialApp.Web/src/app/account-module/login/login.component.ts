import { Component, OnInit, OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator } from '../../core-module/';
import { ILoginModel } from '../../model/account-models';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router'

@Component({
    selector: 'account-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    public loginForm: FormGroup;

    public emailErrors = {
        required: "Email address is required",
        minlength: EmailValidator.minlengthMessage,
        maxlength: EmailValidator.maxlengthMessage,
        invalidEmail: EmailValidator.invalidEmailMessage
    }

    public passwordErrors = {
        required: 'Password is required'
    };

    constructor(private _fb: FormBuilder, private authService: AuthService, private router: Router) { }

    ngOnInit() {
        this.loginForm = this._fb.group({
            EmailAddress: [{ value: 'atul221282@gmail.com', disabled: false }, [
                Validators.required,
                EmailValidator.validateEmail,
            ]],
            Password: ['Cloudno9!', Validators.required],
        });
    }

    submit() {
        this.authService.login(this.loginForm.getRawValue())
            .subscribe(res => {
                this.router.navigate(['/special']);
            });
    }

    cancel() {
        this.loginForm.reset();
    }
}