import { Component, OnInit } from '@angular/core';
import { MenuItem } from '../../model/';

@Component({
    selector: 'core-login-menu',
    templateUrl: './login-menu.component.html',
    styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {

    menuItems: Array<MenuItem>;

    constructor() { }

    ngOnInit() {
        this.menuItems = new Array<MenuItem>();
        this.menuItems.push({ class: "fa-briefcase", text: "Register Company" });
        this.menuItems.push({ class: "fa-user-circle", text: "Register" });
    }
}

