import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'account-register-customer',
    templateUrl: './register-customer.component.html',
    styleUrls: ['./register-customer.component.scss']
})
export class RegisterCustomerComponent implements OnInit {
    user = {
        EmailAddress: "",
        FirstName: "",
        LastName: ""
    };
    constructor() { }

    ngOnInit() {
        this.user = {
            EmailAddress: 'atul',
            FirstName: '',
            LastName: ''
        };
    }

    submit(data: any) {
        alert(JSON.stringify(data));
    }
}
