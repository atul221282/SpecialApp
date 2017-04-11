﻿import { Component, OnInit, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, AbstractControl } from '@angular/forms';


@Component({
    selector: 'form-control-input',
    templateUrl: './form-control-input.component.html',
    styleUrls: ['./form-control-input.component.css']
})
export class FormControlInputComponent implements OnInit, OnChanges {

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
        this.form.valueChanges.subscribe(value => this.setFormMessage(this.form));
    }
    ngOnChanges(data: any) {
    }

    setMessage(c: AbstractControl): void {
        if (!this.validationMessages) return;
        
        this.errorMessages = '';

        if ((c.touched || c.dirty) && c.errors) {
            this.errorMessages = Object.keys(c.errors).map(key => this.validationMessages[key]).join(', ');
        }
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
}
