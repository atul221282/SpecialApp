import { AbstractControl } from '@angular/forms';

export class DateValidator {
    public static invalidDateMessage: string = "Invalid Date";

    static validate(c: AbstractControl) {
        let regex = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/i;
        let errorsMessage: any = {};
        let hasError: boolean = false
        let value: string = c.value;

        if (c.dirty === false && c.pristine === true)
            return null;

        if (!c.value || c.value === null || c.value === '')
            return null;

        let isValid = regex.test(c.value);

        if (isValid === false) {
            errorsMessage.invalidDate = true;
            hasError = true;
        }

        if (value.length > 10) {
            errorsMessage.invalidDate = true;
            hasError = true;
        }

        if (hasError === true)
            return errorsMessage;
    }
}