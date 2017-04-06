import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
@Component({
    selector: 'form-input',
    templateUrl: './md-input.component.html',
    styleUrls: ['./md-input.component.css']
})
export class MdInputComponent implements OnInit {

    @Input() spText: string;
    @Input() spPlaceholder: string;
    @Input() spRequired: boolean;

    @Output() spTextChange: EventEmitter<string> = new EventEmitter()

    public inputForm: FormGroup;

    constructor(private _fb: FormBuilder) { }

    ngOnInit() {
        this.inputForm = this._fb.group({
            spText: this.spText
        });
        let localSpText = this.inputForm.get('spText');
        localSpText.valueChanges.subscribe(value => this.spTextChange.emit(value));

        if (!this.spRequired)
            this.spRequired = false;
        else
            this.spRequired = true;
    }

    onChange($event: string) {
        this.spTextChange.emit($event);
    }
}
