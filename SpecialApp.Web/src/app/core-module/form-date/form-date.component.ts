import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, AbstractControl } from '@angular/forms';

@Component({
    selector: 'form-date',
    templateUrl: './form-date.component.html',
    styleUrls: ['./form-date.component.css']
})
export class FormDateComponent implements OnInit {

    @Input() form: FormGroup;
    @Input() property: string;
    @Input() spPlaceholder: string;
    @Input() spRequired: boolean;
    @Input() validationMessages: any;

    control: AbstractControl;
    errorMessages: string;
    modelValue: string;

    constructor() { }

    ngOnInit() {
        this.control = this.form.get(this.property);
        this.control.valueChanges.subscribe(value => this.setMessage(this.control));
        this.form.valueChanges.subscribe(value => this.setFormMessage(this.form));
    }

    setMessage(c: AbstractControl): void {
        this.setDateValue(c);

        if (!this.validationMessages) return;
        this.errorMessages = '';
        if ((c.touched || c.dirty) && c.errors) {
            this.errorMessages = Object.keys(c.errors).map(key => this.validationMessages[key]).join(', ');
        }
    }

    private setDateValue(c: AbstractControl) {
        if (!c.value || c.value === null || c.value === '')
            return;
    }

    setFormMessage(formGroup: FormGroup) {
        if (!this.validationMessages) return;
        //if child got an error keep that and return
        if (formGroup.get(this.property).errors)
            return;
        this.errorMessages = '';
        if ((formGroup.touched || formGroup.dirty) && formGroup.errors) {
            this.errorMessages = Object.keys(formGroup.errors).map(key => this.validationMessages[key]).join(', ');
        }
    }

    OnFocus() {
        this.spPlaceholder = 'DOB';
    }

    OnFocusOut() {
        this.spPlaceholder = "DOB dd/mm/yyyy";
    }

    OnBlur() {
        let ff = this.control.value;
        debugger;
    }
}
