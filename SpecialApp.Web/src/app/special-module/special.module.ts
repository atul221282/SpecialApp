import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpecialService, ListComponent } from './';
@NgModule({
    imports: [

    ],
    declarations: [
        ListComponent
    ],
    providers: [
        SpecialService
    ],
    bootstrap: [ListComponent]
})
export class SpecialModule { }