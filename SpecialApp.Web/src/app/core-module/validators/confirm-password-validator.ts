import { AbstractControl, ValidatorFn } from '@angular/forms';

export class ConfirmPasswordValidator {

    static confirmPasswordMessage(message?: string): string {
        if (message)
            return message;
        return 'Password do not match';
    }

    static passwordMatcher(passwordName: string, confirmPasswordName: string): ValidatorFn {
        return (c: AbstractControl) => {

            let pwdCtrl = c.get(passwordName);
            let confirmPwdCtrl = c.get(confirmPasswordName);
            
            if (pwdCtrl.pristine || confirmPwdCtrl.pristine)
                return null;
            if (pwdCtrl.value === confirmPwdCtrl.value) {
                return null;
            }

            return { 'match': true };
        }
    }
}