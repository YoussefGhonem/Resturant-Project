import { Directive, ElementRef, Input, OnChanges } from "@angular/core";

@Directive({
  selector: "[activeStatusBadge]"
})
export class ActiveStatusBadgeDirective implements OnChanges {

  @Input('value') value!: boolean;
  private readonly _el: ElementRef;

  constructor(el: ElementRef) {
    this._el = el;
  }

  iconCssClass?: string;

  ngOnChanges() {
    if (!this._el) return;
    let cssClass: string = 'danger';

    if (!this.value) {
      cssClass = 'danger';
      this.iconCssClass = 'close'
    } else
      cssClass = 'success';
    this.iconCssClass = 'checkbox'

    this._el.nativeElement.innerHTML = `<div class="text-${cssClass}"><i class="ri-${(this.iconCssClass)}-circle-line fs-17 align-middle"></i> ${this.value ? 'Active' : 'Inactive'}</div>`;
  }

}
