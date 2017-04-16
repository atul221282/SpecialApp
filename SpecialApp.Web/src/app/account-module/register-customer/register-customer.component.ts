import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator, DateValidator, ConfirmPasswordValidator } from '../../core-module/';
import { AuthService } from '../auth.service';
import { IRegisterCustomer } from '../../model/account-models';

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

    constructor(private _fb: FormBuilder, @Inject('Window') private window: Window, private authService: AuthService) { }

    ngOnInit() {
        this.pwdGroup = this._fb.group({
            Password: ['', Validators.required],
            ConfirmPassword: ['', Validators.required],
        }, { validator: ConfirmPasswordValidator.passwordMatcher('Password', 'ConfirmPassword') });

        this.registerForm = this._fb.group({
            EmailAddress: [{ value: '', disabled: false }, [
                Validators.required,
                EmailValidator.validateEmail,
            ]],
            FirstName: ['', Validators.required],
            LastName: [''],
            UserName: '',
            passwordGroup: this._fb.group({
                Password: ['', Validators.required],
                ConfirmPassword: ['', Validators.required],
            }, { validator: ConfirmPasswordValidator.passwordMatcher('Password', 'ConfirmPassword') }),
            PhoneNumber: [''],
            DateOfBirth: [new Date('12/22/1982'), [
                Validators.required,
                DateValidator.validate
            ]]
        });
    }

    submit(data: any) {
        let model = this.registerForm.getRawValue();
        this.authService.createUser(model as IRegisterCustomer, model.passwordGroup.Password);
    }

    cancel() {
        this.registerForm.reset();
    }
}