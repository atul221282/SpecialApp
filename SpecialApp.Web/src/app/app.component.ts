import { Component } from '@angular/core';
import { ApiClientService } from './core-module/api-client.service';
import { Router, NavigationEnd } from '@angular/router';
import { MainCoreService } from './core-module/main-core.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})

export class AppComponent {
    constructor(private apiClientService: ApiClientService, private router: Router,
        private mainCoreService: MainCoreService) {
        this.router.events.subscribe((val) => {
            if (val && val instanceof NavigationEnd) {
                console.info(val.url);
                this.mainCoreService.StorageService.setItem(
                    this.mainCoreService.MainConstantService.commonVariable.previous_url,
                    val.url);
            }
        });
    }
}