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

    constructor(private router: Router) { }

    ngOnInit() {
        this.menuItems = new Array<MenuItem>();
        this.menuItems.push({ class: "fa-briefcase", text: "Login", href: "account/login" });
        this.menuItems.push({ class: "fa-user", text: "Register User", href: "account/add-customer" });
        this.menuItems.push({ class: "fa-user", text: "Register Franchise", href: "franchise/register" });
        this.menuItems.push({ class: "fa-key", text: "Forgot Password", href: "account/forgot-password" });
    }

    navigate(href: string) {
        this.router.navigate([href]);
    }
}

