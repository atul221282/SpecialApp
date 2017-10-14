import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiClientService } from 'app';
import { SpecialService } from 'app/special-module';

@Component({
    selector: 'special-list',
    templateUrl: './special-list.component.html',
    styleUrls: ['./special-list.component.scss']
})

export class SpecialListComponent implements OnInit {
    specials: any[] = [];
    constructor(private specialService: SpecialService) { }

    ngOnInit() {
        this.specialService.getUserLocation().subscribe((data: Position) => {
            this.specialService.getByLocation(data).subscribe((specials: any[]) => {
                this.specials = specials;
            });
        });
    }
}
