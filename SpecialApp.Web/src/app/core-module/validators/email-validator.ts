import { FormControl } from '@angular/forms';

export class EmailValidator {
    static validateEmail(control: FormControl) {
        
        if (control.value.indexOf(' ') >= 0)
            return { invalidEmail: true };
        return null;
    }
}