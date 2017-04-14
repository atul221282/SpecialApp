import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator, DateValidator } from '../../core-module/';

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
        match: 'Password do not match'
    };

    public pwdGroup: AbstractControl;
    public confirmPasswordError: string;
    public foods: Array<any>;

    constructor(private _fb: FormBuilder, @Inject('Window') private window: Window) { }

    ngOnInit() {

        setTimeout(() => {
            this.foods = [
                { value: 1, viewValue: 'Steak' },
                { value: 2, viewValue: 'Pizza' },
                { value: 3, viewValue: 'Tacos' }
            ];
        }, 3000)

        this.pwdGroup = this._fb.group({
            Password: ['', Validators.required],
            ConfirmPassword: ['', Validators.required],
        }, { validator: passwordMatcher });

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
            }, { validator: passwordMatcher }),
            FoodType: [null, Validators.required],
            PhoneNumber: ['', Validators.required],
            DateOfBirth: ['', [
                Validators.required,
                DateValidator.validate
            ]]
        });
    }

    submit(data: any) {
        alert(JSON.stringify(this.registerForm.getRawValue()));
    }

    cancel() {
        this.registerForm.reset();
    }
}

