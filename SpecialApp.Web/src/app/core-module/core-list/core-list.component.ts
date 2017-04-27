import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ApiClientService } from '../api-client.service';
import { IBaseCode } from '../../model/';

@Component({
    selector: 'core-list',
    templateUrl: './core-list.component.html',
    styleUrls: ['./core-list.component.css']
})
export class CoreListComponent implements OnInit {

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
}
