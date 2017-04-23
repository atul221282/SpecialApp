import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SpecialRouterModule, routedComponents } from './special-routing.module';
import { CanActivateSpecialGuard } from './guard/can-activate-special-guard';
import {CanDeactivateSpecialGuardService } from './guard/can-deactivate-special-guard.service';

@NgModule({
    imports: [CommonModule, FormsModule, SpecialRouterModule],
    declarations: [routedComponents],
    providers: [CanActivateSpecialGuard, CanDeactivateSpecialGuardService]
})
export class SpecialModule { }


/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/