import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'form-select',
    templateUrl: './form-select.component.html',
    styleUrls: ['./form-select.component.css']
})
export class FormSelectComponent implements OnInit {
    @Input() list: Array<any>;
    @Input() spTextField: string;
    constructor() { }

    ngOnInit() {
    }
    getText(data: any) {
        let text = data[this.spTextField];
        return text;
    }
}
