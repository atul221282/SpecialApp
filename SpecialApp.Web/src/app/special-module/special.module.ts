import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MdCardModule, MdButtonModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

import { CoreModule } from '../core-module/core.module';
import { SpecialRouterModule, routedComponents } from './special-routing.module';
import { CanActivateSpecialGuard } from './guard/can-activate-special-guard';
import { CanDeactivateSpecialGuardService } from './guard/can-deactivate-special-guard.service';
import { SpecialService } from 'app/special-module';

@NgModule({
    imports: [CommonModule, FormsModule, MdCardModule, MdButtonModule, FlexLayoutModule, SpecialRouterModule, CoreModule],
    declarations: [routedComponents],
    providers: [SpecialService, CanActivateSpecialGuard, CanDeactivateSpecialGuardService]
})
export class SpecialModule { }


/*
Copyright 2016 JohnPapa.net, LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://bit.ly/l1cense
*/
