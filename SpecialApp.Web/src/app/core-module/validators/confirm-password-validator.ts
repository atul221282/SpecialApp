import { AbstractControl } from '@angular/forms';

export class ConfirmPasswordValidator {

    static passwordMatcher(c: AbstractControl) {
        let pwdCtrl = c.get('Password');
        let confirmPwdCtrl = c.get('ConfirmPassword');

        if (pwdCtrl.pristine || confirmPwdCtrl.pristine)
            return null;
        if (pwdCtrl.value === confirmPwdCtrl.value) {
            return null;
        }
        return { 'match': true };
    }
}