import { Component, OnInit, OnChanges } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent
    implements OnInit, OnChanges {

    title = 'Angular app works! YAY';

    ngOnInit() {
        setTimeout(() => {
            this.title = "Changes after 5 secs";
        }, 5000);
    }
    ngOnChanges() {
    }
}
