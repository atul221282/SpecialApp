import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
@Component({
    selector: 'form-input',
    templateUrl: './md-input.component.html',
    styleUrls: ['./md-input.component.css']
})
export class MdInputComponent implements OnInit {
    @Input() spInput: string;
    @Input() spPlaceholder: string;

    @Output() spInputChange: EventEmitter<string> = new EventEmitter()

    constructor() { }

    ngOnInit() {
    }

    onChange($event: string) {
        this.spInputChange.emit($event);
    }
}
