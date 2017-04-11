import { Component, OnInit, Inject } from '@angular/core';
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

    public foodTypeMessage = {
        required: 'Food type is required'
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
            ]],
            FirstName: ['', Validators.required],
            LastName: [''],
            UserName: '',
            passwordGroup: this._fb.group({
                Password: ['', Validators.required],
                ConfirmPassword: ['', Validators.required],
            }, { validator: passwordMatcher }),
            FoodType: [null, Validators.required],
            PhoneNumber: ''
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