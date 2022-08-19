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

  ngOnChanges() {
    if (!this._el) return;
    let cssClass: string = 'danger';

    if (!this.value)
      cssClass = 'danger';
    else
      cssClass = 'success';

    this._el.nativeElement.innerHTML = `<div class="badge bg-${cssClass}">${this.value ? 'Active' : 'Inactive'}</div>`;
  }

}
