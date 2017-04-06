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
    control: AbstractControl;
    constructor() { }

    ngOnInit() {
        this.control = this.form.get(this.property);
    }

}
