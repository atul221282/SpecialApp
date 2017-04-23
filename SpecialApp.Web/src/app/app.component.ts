import { Component, OnInit } from '@angular/core';
import { ApiClientService } from './core-module/api-client.service';
import { Router, NavigationEnd} from '@angular/router';
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    constructor(private apiClientService: ApiClientService, private router: Router) {
        this.router.events.subscribe((val) => {
            if (val && val instanceof NavigationEnd) {
                console.info(val.url);
                localStorage.setItem('previousRoute', val.url);
            }
        });
    }

    ngOnInit() {
       
    }
}