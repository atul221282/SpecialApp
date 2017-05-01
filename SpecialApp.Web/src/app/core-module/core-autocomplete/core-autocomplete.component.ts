import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ApiClientService } from '../api-client.service';
import { IBaseCode } from '../../model/';

@Component({
    selector: 'core-autocomplete',
    templateUrl: './core-autocomplete.component.html',
    styleUrls: ['./core-autocomplete.component.css']
})
export class CoreAutocompleteComponent implements OnInit, OnChanges {

    @Input() lpName: string;
    @Input() spTextField: string;
    @Input() spValueField: string;
    @Input() form: FormGroup;
    @Input() property: string;
    @Input() validationMessages: any;
    @Input() spPlaceholder: string;

    AddressTypes: Array<any>;
    constructor(
        private service: ApiClientService
    ) { }

    ngOnInit() {
        this.service
            .get(`lookup/${this.lpName}`)
            .subscribe(response => this.AddressTypes = response as Array<IBaseCode>);
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['lpName']) {
            if (changes['lpName'].currentValue !== changes['lpName'].previousValue
                && changes['lpName'].isFirstChange() === false) {
                this.service
                    .get(`lookup/${this.lpName}`)
                    .subscribe(response => this.AddressTypes = response as Array<IBaseCode>);
            }
        }

    }
}
