import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'core-address-list',
    templateUrl: './address-list.component.html',
    styleUrls: ['./address-list.component.css']
})
export class AddressListComponent implements OnInit {

    @Input() spTextField: string;
    @Input() spValueField: string;
    @Input() form: FormGroup;
    @Input() property: string;
    @Input() validationMessages: any;


    AddressTypes: Array<any>;
    constructor() { }

    ngOnInit() {
        this.AddressTypes = [
            { Id: 1, Description: "Home", RowVersion: null },
            { Id: 2, Description: "Postal", RowVersion: null },
            { Id: 3, Description: "Office", RowVersion: null }
        ];
    }

}
