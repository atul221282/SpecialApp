import { NgModule } from '@angular/core';
import { FranchiseRouterModule, routedComponents } from './franchise-routing.module';
import { CoreModule } from '../core-module/core.module';


@NgModule({
    imports: [
        FranchiseRouterModule,
        CoreModule
    ],
    providers: [{ provide: 'Window', useValue: window }],
    declarations: [routedComponents]
})
export class FranchiseModule { }
