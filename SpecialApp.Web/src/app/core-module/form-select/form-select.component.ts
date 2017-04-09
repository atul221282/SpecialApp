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

    //selectedValue: string;
    //constructor() { }

    //ngOnInit() {
    //}

    stateCtrl: FormControl;
    idControl: FormControl;
    filteredStates: any;
    stateValue: string;

    constructor() {
        this.stateCtrl = new FormControl();
        this.idControl = new FormControl();
        
    }
    ngOnInit() {
        this.stateValue = undefined;
        this.filteredStates = this.stateCtrl.valueChanges
            .startWith(null)
            .map(name => this.filterStates(name));
        this.stateCtrl.valueChanges.subscribe(value => this.setForm(this.stateCtrl, this.form));
    }

    filterStates(val: string) {

        var lis= val ? this.list.filter(s => new RegExp(`^${val}`, 'gi').test(s[this.spTextField]))
            : this.list;

        return lis;
    }
    getValue(c: FormControl) {

    }
    setForm(c: FormControl, form: FormGroup) {
        if (c.value && c.value !== null) {
            if (c.value[this.spValueField] && c.value[this.spValueField] !== null) {
                this.stateValue = c.value[this.spTextField];
                this.form.get(this.property).setValue(c.value.value);
            }
            else {
                this.form.get(this.property).setValue(null);
                this.stateValue = "";
            }
        }
        else {
            this.stateValue = "";
            this.form.get(this.property).setValue(null);
        }
        
    }

}
