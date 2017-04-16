import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, AbstractControl, FormControl } from '@angular/forms';
import 'rxjs/add/operator/debounceTime';
import * as moment from 'moment';

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

    get parentControl(): FormControl {
        return this.form.get(this.property) as FormControl;
    }

    control: AbstractControl;
    errorMessages: string;
    modelValue: string;
    tooltipPosition: string;
    debounceTime: number = 1000;
    constructor() { }

    ngOnInit() {
        this.tooltipPosition = "before";
        this.control = new FormControl();
        let dd = moment(this.form.get(this.property).value).format('MM/DD/YYYY');
        this.control.setValue(dd);

        this.control.valueChanges.debounceTime(this.debounceTime).subscribe(value => this.setMessage(this.parentControl));

        this.form.valueChanges.debounceTime(this.debounceTime).subscribe(value => this.setFormMessage(this.form));
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
        c.markAsDirty();
        c.markAsTouched();

        if (!c.value || c.value === null || c.value === '')
            return;
        
        c.setValue(new Date(this.control.value));
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
        this.spPlaceholder = "DOB mm/dd/yyyy";
    }

}
