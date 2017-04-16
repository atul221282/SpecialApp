import { AbstractControl } from '@angular/forms';
import * as moment from 'moment';

export class DateValidator {
    public static invalidDateMessage: string = "Invalid Date";

    static validate(c: AbstractControl) {

        let errorsMessage: any = {};
        let hasError: boolean = false
        let value: string = c.value;

        if (c.dirty === false && c.pristine === true)
            return null;

        if (!c.value || c.value === null || c.value === '')
            return null;

        let isValid = moment(c.value, ['MM/DD/YYYY', 'MM-DD-YYYY', 'MM-DD-YY'], true).isValid();
        
        if (isValid === false) {
            errorsMessage.invalidDate = true;
            hasError = true;
        }

        if (value.length > 10) {
            errorsMessage.invalidDate = true;
            hasError = true;
        }

        if (new Date(value).getFullYear() <= 1500) {
            errorsMessage.invalidDate = true;
            hasError = true;
        }

        if (hasError === true)
            return errorsMessage;
    }
}