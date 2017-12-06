import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgModule } from '@angular/core';
import { ListComponent } from './list/list.component';
import { routedComponents, SpecialRouterModule } from './special-routing.module';
import { SpecialService } from "../shared/special.service";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SpecialRouterModule,
  ],
  declarations: [routedComponents],
  providers: [SpecialService]
})
export class SpecialModule { }
