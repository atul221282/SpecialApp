import { FormControl } from '@angular/forms';

export class EmailValidator {
    static validateEmail(control: FormControl) {
        let errorsMessage: any = {};
        let hasError: boolean = false
        let value: string = control.value;
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
    public static invalidEmail: string = "Email address is invalid";
}