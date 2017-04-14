import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { EmailValidator } from '../../core-module/';

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
        invalidEmail: "Invalid email"
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
        maxlength: 'Length can\'t be greater than 10',
        pattern: 'Invalid DOB fromat'
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
                Validators.minLength(5),
                Validators.maxLength(50),
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
                Validators.maxLength(10),
                Validators.pattern(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)]]
        });
    }

    submit(data: any) {
        alert(JSON.stringify(this.registerForm.getRawValue()));
    }

    cancel() {
        this.registerForm.reset();
    }
}

function passwordMatcher(c: AbstractControl) {
    let pwdCtrl = c.get('Password');
    let confirmPwdCtrl = c.get('ConfirmPassword');

    if (pwdCtrl.pristine || confirmPwdCtrl.pristine)
        return null;
    if (pwdCtrl.value === confirmPwdCtrl.value) {
        return null;
    }
    return { 'match': true };
}