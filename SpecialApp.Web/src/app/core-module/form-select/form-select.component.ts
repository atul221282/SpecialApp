import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
@Component({
    selector: 'form-select',
    templateUrl: './form-select.component.html',
    styleUrls: ['./form-select.component.css']
})
export class FormSelectComponent {
    //@Input() list: Array<any>;
    //@Input() spTextField: string;
    //@Input() spValueField: string;
    //@Input() form: FormGroup;
    //@Input() property: string;

    //selectedValue: string;
    //constructor() { }

    //ngOnInit() {
    //}

    stateCtrl: FormControl;
    filteredStates: any;

    states = [
        'Alabama',
        'Alaska',
        'Arizona',
        'Arkansas',
        'California',
        'Colorado',
        'Connecticut',
        'Delaware',
        'Florida',
        'Georgia',
        'Hawaii',
        'Idaho',
        'Illinois',
        'Indiana',
        'Iowa',
        'Kansas',
        'Kentucky',
        'Louisiana',
        'Maine',
        'Maryland',
        'Massachusetts',
        'Michigan',
        'Minnesota',
        'Mississippi',
        'Missouri',
        'Montana',
        'Nebraska',
        'Nevada',
        'New Hampshire',
        'New Jersey',
        'New Mexico',
        'New York',
        'North Carolina',
        'North Dakota',
        'Ohio',
        'Oklahoma',
        'Oregon',
        'Pennsylvania',
        'Rhode Island',
        'South Carolina',
        'South Dakota',
        'Tennessee',
        'Texas',
        'Utah',
        'Vermont',
        'Virginia',
        'Washington',
        'West Virginia',
        'Wisconsin',
        'Wyoming',
    ];

    constructor() {
        this.stateCtrl = new FormControl();
        this.filteredStates = this.stateCtrl.valueChanges
            .startWith(null)
            .map(name => this.filterStates(name));
    }

    filterStates(val: string) {
        return val ? this.states.filter(s => new RegExp(`^${val}`, 'gi').test(s))
            : this.states;
    }

}
