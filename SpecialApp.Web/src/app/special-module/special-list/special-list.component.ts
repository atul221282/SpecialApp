import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiClientService } from 'app';
import { SpecialService } from 'app/special-module';

@Component({
    selector: 'special-list',
    templateUrl: './special-list.component.html',
    styleUrls: ['./special-list.component.css']
})

export class SpecialListComponent implements OnInit {
    specials: any[] = [];
    constructor(private specialService: SpecialService) { }

    ngOnInit() {
        this.specialService.getByLocation().subscribe((data: any[]) => {
            this.specials = data;
        });
    }
}
