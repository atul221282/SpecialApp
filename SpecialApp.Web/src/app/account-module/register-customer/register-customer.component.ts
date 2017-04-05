import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'account-register-customer',
    templateUrl: './register-customer.component.html',
    styleUrls: ['./register-customer.component.scss']
})
export class RegisterCustomerComponent implements OnInit {
    emailAddress: string;
    constructor() { }

    ngOnInit() {
        this.emailAddress = 'atul';
    }
}
