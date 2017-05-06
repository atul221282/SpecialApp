import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator, DateValidator, ConfirmPasswordValidator } from '../../core-module/';
import { CustomerAccountService } from '../customer-account.service';
import { IRegisterCustomer } from '../../model/account-models';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Rx';
import { FormGroupService } from '../../form-control-module/form-group/form-group.service';
@Component({
    selector: 'account-register-customer',
    templateUrl: './register-customer.component.html',
    styleUrls: ['./register-customer.component.scss']
})
export class RegisterCustomerComponent implements OnInit {

    public registerForm: FormGroup;

    public emailErrors = {
        required: "Email address is required",
        minlength: EmailValidator.minlengthMessage,
        maxlength: EmailValidator.maxlengthMessage,
        invalidEmail: EmailValidator.invalidEmailMessage
    }
    public firstName = {
        required: "First name is required"
    }
    public lastName = {
        required: "Surname is required"
    }
    public passwordMessage = {
        required: 'Password is required'
    };
    public foodTypeMessage = {
        required: 'Food type is required'
    };
    public phoneMessage = {
        required: 'Phone number is required'
    };
    public dobMessage = {
        required: 'DOB is required',
        invalidDate: DateValidator.invalidDateMessage
    };
    public confirmPasswordMessage = {
        required: 'Confirm password is required',
        match: ConfirmPasswordValidator.confirmPasswordMessage('Password and confirm password do not match')
    };

    public pwdGroup: AbstractControl;
    public confirmPasswordError: string;
    public foods: Array<any>;
    public submitCall: Subscription;
    constructor(private _fb: FormBuilder, 
        private customerAccount: CustomerAccountService, private router: Router,
        private formGroupService: FormGroupService) { }

    ngOnInit() {
        
        this.pwdGroup = this.formGroupService.confirmPassword.getFormGroup();

        this.registerForm = this._fb.group({
            EmailAddress: [{ value: 'atul221282@gmail.com', disabled: false }, [
                Validators.required,
                EmailValidator.validateEmail,
            ]],
            FirstName: ['Atul', Validators.required],
            LastName: ['Chaudhary'],
            UserName: 'atul221282',
            passwordGroup: this.pwdGroup,
            PhoneNumber: ['0430499210'],
            DateOfBirth: [new Date('12/22/1982'), [
                Validators.required,
                DateValidator.validate
            ]]
        });
    }

    submit(data: any) {
        let model = this.registerForm.getRawValue();
        this.submitCall = this.customerAccount.createUser(model as IRegisterCustomer, model.passwordGroup.Password)
            .subscribe(res => {
                this.router.navigate(['account/login']);
            });
    }

    ngOnDestroy() {
        if (this.submitCall) {
            this.submitCall.unsubscribe();
        }
    }

    cancel() {
        this.registerForm.reset();
    }
}