import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'form-select',
    templateUrl: './form-select.component.html',
    styleUrls: ['./form-select.component.css']
})
export class FormSelectComponent implements OnInit {
    @Input() list: Array<any>;
    @Input() spTextField: string;
    @Input() spValueField: string;

    selectedValue: string;
    constructor() { }

    ngOnInit() {
    }
    
}
