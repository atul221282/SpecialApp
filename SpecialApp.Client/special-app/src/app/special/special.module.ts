import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgModule } from '@angular/core';
import { ListComponent } from './list/list.component';
import { routedComponents, SpecialRouterModule } from './special-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SpecialRouterModule,
  ],
  declarations: [routedComponents],
  providers: []
})
export class SpecialModule { }
