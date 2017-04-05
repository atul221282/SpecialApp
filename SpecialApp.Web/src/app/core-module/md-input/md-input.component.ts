import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
@Component({
    selector: 'form-input',
    templateUrl: './md-input.component.html',
    styleUrls: ['./md-input.component.css']
})
export class MdInputComponent implements OnInit {
    @Input() spText: string;
    @Input() spPlaceholder: string;
    @Input() spRequired: boolean;


    @Output() spInputChange: EventEmitter<string> = new EventEmitter()

    constructor() { }

    ngOnInit() {
        if (!this.spRequired)
            this.spRequired = false;
        else
            this.spRequired = true;
    }

    onChange($event: string) {
        this.spInputChange.emit($event);
    }
}
