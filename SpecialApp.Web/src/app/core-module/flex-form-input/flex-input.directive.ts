import { Directive, ElementRef, Renderer, OnInit } from '@angular/core';

@Directive({
    selector: '[coreFlexInput]'
})
export class FlexInputDirective implements OnInit {

    constructor(private el: ElementRef, private renderer: Renderer) {
        // Use renderer to render the element with 50
    }

    ngOnInit() {
        this.renderer.setElementClass(this.el.nativeElement, "padding-5", true);
        this.renderer.setElementStyle(this.el.nativeElement, "line-height", "50px");
        this.renderer.setElementStyle(this.el.nativeElement, "vertical-align", "middle");
    }
}
