import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiClientService } from 'app';

@Component({
    selector: 'special-list',
    templateUrl: './special-list.component.html',
    styleUrls: ['./special-list.component.css']
})

export class SpecialListComponent implements OnInit, OnDestroy {

    constructor(private apiClient: ApiClientService) { }

    ngOnInit() {
        this.apiClient.get('Special/122').subscribe((data) => {
            debugger;
        });
    }

    ngOnDestroy() {
    }
}
