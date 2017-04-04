import { Component, OnInit } from '@angular/core';
import { MenuItem } from '../../model/';
import { Router } from '@angular/router'


@Component({
    selector: 'core-login-menu',
    templateUrl: './login-menu.component.html',
    styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {

    menuItems: Array<MenuItem>;

    constructor(private router:Router) { }

    ngOnInit() {
        this.menuItems = new Array<MenuItem>();
        this.menuItems.push({ class: "fa-briefcase", text: "Register Company", href: "account/login" });
        this.menuItems.push({ class: "fa-user-circle", text: "Register", href: "account/add-customer" });
        this.menuItems.push({ class: "fa-key", text: "Forgot Password", href: "account/forgot-password" });
        //forgot-password
    }

    navigate(href: string) {
        this.router.navigate([href]);
    }
}

