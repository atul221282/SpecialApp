﻿import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';
@Component({
    selector: 'form-select',
    templateUrl: './form-select.component.html',
    styleUrls: ['./form-select.component.css']
})
export class FormSelectComponent implements OnInit {
    @Input() list: Array<any>;
    @Input() spTextField: string;
    @Input() spValueField: string;
    @Input() form: FormGroup;
    @Input() property: string;
    @Input() validationMessages: any;

    parentControl: AbstractControl;
    control: AbstractControl;
    errorMessages: string;
    filteredStates: any;

    constructor() {
        this.control = new FormControl();
    }

    ngOnInit() {
        this.parentControl = this.form.get(this.property);
        this.filteredStates = this.control.valueChanges
            .startWith(null)
            .map(name => this.filterStates(name));
        this.control.valueChanges.subscribe(value => this.checkControl(this.control));

        this.parentControl.valueChanges.subscribe(value => this.setForm());
    }

    filterStates(val: string) {
        return this.list;
    }

    checkControl(c: AbstractControl) {
        debugger;
        if (!c.value[this.spValueField] || c.value[this.spValueField] === null) {
            let control = this.parentControl;
            control.markAsDirty();
            control.markAsTouched();
            control.setValue(null);
        }
    }

    setForm() {
        this.setMessage(this.parentControl);
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

    displayFn(data: any) {
        return data ? data[this.spTextField] : data;
    }

    selected(data: any) {
        this.parentControl.setValue(data[this.spValueField]);
    }

}
