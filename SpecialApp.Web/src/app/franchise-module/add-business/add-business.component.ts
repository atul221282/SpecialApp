import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-add-business',
    templateUrl: './add-business.component.html',
    styleUrls: ['./add-business.component.css']
})
export class AddBusinessComponent implements OnInit {

    navLinks = [
        { label: "Add User" },
        { label: "Add Franchise" },
        { label: "Add Company" }
    ];
    constructor() { }

    ngOnInit() {
    }

}
