import { Component, OnInit, OnChanges, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator } from '../../core-module/';
import { ILoginModel } from '../../model/account-models';
import { AuthService } from '../auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Rx';
import { IToken } from '../../model/';
import { MainCoreService } from '../../core-module/main-core.service';
import {AutoUnsubscribe } from '../../core-module/auto-unsubscribe';

@AutoUnsubscribe()
@Component({
    selector: 'account-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    public loginForm: FormGroup;
    public submitWatcher: Subscription;
    public routeParamsWatcher: Subscription;

    returnUrl: string;

    public emailErrors = {
        required: "Email address is required",
        minlength: EmailValidator.minlengthMessage,
        maxlength: EmailValidator.maxlengthMessage,
        invalidEmail: EmailValidator.invalidEmailMessage
    }
    public passwordErrors = {
        required: 'Password is required'
    };

    constructor(private _fb: FormBuilder, private authService: AuthService,
        private router: Router, private mainCoreService: MainCoreService,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        this.routeParamsWatcher = this.route
            .queryParams
            .subscribe(params => {
                this.returnUrl = params['returnUrl'];
            });

        this.loginForm = this._fb.group({
            EmailAddress: [{ value: 'atul221282@gmail.com', disabled: false }, [
                Validators.required,
                EmailValidator.validateEmail,
            ]],
            Password: ['Cloudno9!', Validators.required],
        });
    }

    submit() {
        this.submitWatcher = this.authService.login(this.loginForm.getRawValue())
            .subscribe(res => {
                if (this.returnUrl) {
                    this.router.navigate([this.returnUrl]);
                }
                else {
                    this.router.navigate(['/special']);
                }
            }, (error) => {
                alert(JSON.stringify(error.data));
            });
    }

    ngOnDestroy() {
    }

    cancel() {
        this.loginForm.reset();
    }
}