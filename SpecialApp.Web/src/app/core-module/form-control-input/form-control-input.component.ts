import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, AbstractControl } from '@angular/forms';


@Component({
    selector: 'form-control-input',
    templateUrl: './form-control-input.component.html',
    styleUrls: ['./form-control-input.component.css']
})
export class FormControlInputComponent implements OnInit {

    @Input() form: FormGroup;
    @Input() property: string;
    @Input() spPlaceholder: string;
    @Input() spRequired: boolean;
    @Input() validationMessages: any;

    control: AbstractControl;
    errorMessages: string;
    constructor() { }

    ngOnInit() {
        this.control = this.form.get(this.property);
        this.control.valueChanges.subscribe(value => this.setMessage(this.control));
    }

    setMessage(c: AbstractControl): void {
        if (!this.validationMessages) return;
        this.errorMessages = '';
        if ((c.touched || c.dirty) && c.errors) {
            this.errorMessages = Object.keys(c.errors).map(key => this.validationMessages[key]).join(', ');
        }
    }
}
