import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';

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

    public passwordMessage = {
        required: 'Password is required'
    };
    public confirmPasswordMessage = {
        required: 'Confirm password is required',
        match: 'Password do not match'
    };

    public pwdGroup: AbstractControl;
    public confirmPasswordError: string;
    public foods: Array<any>;

    constructor(private _fb: FormBuilder) { }



    ngOnInit() {
        this.foods = [
            { value: 'steak-0', viewValue: 'Steak' },
            { value: 'pizza-1', viewValue: 'Pizza' },
            { value: 'tacos-2', viewValue: 'Tacos' }
        ];

        this.pwdGroup = this._fb.group({
            Password: ['', Validators.required],
            ConfirmPassword: ['', Validators.required],
        }, { validator: passwordMatcher });

        this.registerForm = this._fb.group({
            EmailAddress: [{ value: '', disabled: false }, [
                Validators.required,
                Validators.minLength(5),
                Validators.maxLength(50),
            ]],
            FirstName: ['', Validators.required],
            LastName: [''],
            UserName: '',
            passwordGroup: this._fb.group({
                Password: ['', Validators.required],
                ConfirmPassword: ['', Validators.required],
            }, { validator: passwordMatcher }),
            PhoneNumber: ''
        });
        //this.pwdGroup.valueChanges.subscribe(value => this.onPwdGroupChange(this.pwdGroup))
    }

    submit(data: any) {
        alert(JSON.stringify(this.registerForm.getRawValue()));
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