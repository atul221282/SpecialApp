import { Component } from '@angular/core';
import { ApiClientService } from './';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'app works!';

    constructor(private apiClientService: ApiClientService) {
        this.getValues();
        this.getValue()
    }

    getValues() {
        this.apiClientService.get<string[]>('values').subscribe(
            comments => {
                console.dir(comments);
            },
            err => {
                console.log(err);
            });
    }

    getValue() {
        this.apiClientService.get<string>('values/1').subscribe(
            comments => {
                console.info(comments);
            },
            err => {
                console.log(err);
            });
    }
}