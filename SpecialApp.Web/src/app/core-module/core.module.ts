import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingSpinnerComponent, ApiClientService } from './';

@NgModule({
    imports: [
        
    ],
    declarations: [
        LoadingSpinnerComponent
    ],
    providers: [
        ApiClientService
    ]
})
export class CoreModule { }
