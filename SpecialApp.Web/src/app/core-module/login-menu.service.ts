import { Injectable } from '@angular/core';
import { MenuItem } from '../model';

@Injectable()
export class LoginMenuService {

    menuItems: Array<MenuItem>;

    constructor() {
        this.menuItems = new Array<MenuItem>();
        this.menuItems.push({ class: "fa-briefcase", text: "Login", href: "account/login" });
        this.menuItems.push({ class: "fa-user", text: "Register User", href: "account/add-customer" });
        this.menuItems.push({ class: "fa-key", text: "Forgot Password", href: "account/forgot-password" });
    }

}
