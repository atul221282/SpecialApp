import { Component, OnInit } from '@angular/core';
import { MainCoreService } from '../main-core.service';

@Component({
    selector: 'core-toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

    constructor(private mainCoreService: MainCoreService) { }

    ngOnInit() {
        
    }

}
