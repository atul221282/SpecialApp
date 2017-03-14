import { Component, OnInit, OnChanges } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    title = 'Angular app works! YAY';

    ngOnInit() {
        setTimeout(() => {
            this.title = "Changes after 5 secs";
        }, 5000);
    }
}