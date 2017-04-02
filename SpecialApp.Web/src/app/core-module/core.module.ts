import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingSpinnerComponent, ApiClientService } from './';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
    imports: [
        MaterialModule,
        FlexLayoutModule
    ],
    declarations: [
        LoadingSpinnerComponent,
        ToolbarComponent
    ],
    exports: [
        LoadingSpinnerComponent,
        ToolbarComponent
    ],
    providers: [
        ApiClientService
    ]
})
export class CoreModule { }