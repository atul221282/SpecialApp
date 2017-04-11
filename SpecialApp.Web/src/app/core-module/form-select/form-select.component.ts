import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
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

    stateCtrl: FormControl;
    filteredStates: any;

    constructor() {
        this.stateCtrl = new FormControl();
    }

    ngOnInit() {
        this.filteredStates = this.stateCtrl.valueChanges
            .startWith(null)
            .map(name => this.filterStates(name));
        this.stateCtrl.valueChanges.subscribe(value => this.setForm(this.stateCtrl, this.form));
    }

    filterStates(val: string) {
        return this.list;
    }

    setForm(c: FormControl, form: FormGroup) {
        this.form.get(this.property).setValue(null);
        if (c.value && c.value !== null) {
            if (c.value[this.spValueField] && c.value[this.spValueField] !== null) {
                this.form.get(this.property).setValue(c.value.value);
            }
        }
    }

    displayFn(data: any) {
        return data ? data[this.spTextField] : data;
    }

}
