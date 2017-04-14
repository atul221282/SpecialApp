import { FormControl } from '@angular/forms';

export class EmailValidator {
    public static invalidEmailMessage: string = "Email address is invalid";
    public static minlengthMessage: string = "Emaill address can't be less than 5 characters";
    public static maxlengthMessage: string = "Emaill address can't be greater than 50 characters";

    static validateEmail(control: FormControl) {
        let errorsMessage: any = {};
        let hasError: boolean = false
        let value: string = control.value;

        if (control.dirty === false && control.pristine === true) {
            return null;
        }

        if (!control.value || control.value === null || control.value === '')
            return null;

        if (value.indexOf(' ') >= 0) {
            errorsMessage.invalidEmail = true;
            hasError = true;
        }

        if (value.length <= 5) {
            errorsMessage.minlength = true;
            hasError = true;
        }

        if (value.length > 50) {
            errorsMessage.maxlength = true;
            hasError = true;
        }

        if (hasError === true)
            return errorsMessage;

        return null;
    }
}