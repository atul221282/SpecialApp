import { Component } from '@angular/core';
import { ApiClientService } from './core-module/api-client.service';
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    constructor(private apiClientService: ApiClientService) {
        //this.getValues();
        this.getValue()
    }

    getValue() {
        this.apiClientService.get<string[]>('values/1').subscribe(
            comments => {
                console.dir(comments);
            },
            err => {
                console.log(err);
            });
    }

}

//import { Component } from '@angular/core';
//import { ApiClientService } from './';

//@Component({
//    selector: 'app-root',
//    templateUrl: './app.component.html',
//    styleUrls: ['./app.component.css']
//})
//export class AppComponent {
//    title = 'app works!';




//    getValue() {
//        this.apiClientService.get<string>('values/1').subscribe(
//            comments => {
//                console.info(comments);
//            },
//            err => {
//                console.log(err);
//            });
//        this.apiClientService.get<any>('location/4000').subscribe(
//            location => {
//                console.info(location);
//            },
//            err => {
//                console.log(err);
//            });
//    }
//}