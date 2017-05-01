import { Component, Input, OnInit, OnChanges } from '@angular/core';
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
    @Input() spPlaceholder: string;
    @Input() validationMessages: any;

    constructor() { }

    ngOnInit() {
    }

}
