import { Component, OnInit } from '@angular/core';
import { MenuItem } from '../../model/';
import { Router } from '@angular/router'
import { MainCoreService } from '../main-core.service';

@Component({
    selector: 'core-user-menu',
    templateUrl: './core-user-menu.component.html',
    styleUrls: ['./core-user-menu.component.css']
})
export class CoreUserMenuComponent implements OnInit {

    menuItems: Array<MenuItem>;

    constructor(private router: Router, private mainCoreService: MainCoreService) { }

    ngOnInit() {
        this.menuItems = new Array<MenuItem>();
        this.menuItems.push({ class: "fa-briefcase", text: "Account", href: "account/login" });
        this.menuItems.push({ class: "fa-user", text: "Profile", href: "account/add-customer" });
        this.menuItems.push({ class: "fa-key", text: "Logout", href: "logout" });
    }

    navigate(href: string) {
        switch (href) {
            case 'logout':
                {
                    this.mainCoreService.StorageService.removeItem(this.mainCoreService.MainConstantService.variables.access_token);
                    this.router.navigate(['account/login']);
                    break;
                }
            default:
                this.router.navigate([href]);
        }
    }
}
