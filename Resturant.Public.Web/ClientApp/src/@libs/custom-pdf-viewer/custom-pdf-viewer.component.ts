import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'custom-pdf-viewer',
  templateUrl: './custom-pdf-viewer.component.html',
  styleUrls: ['./custom-pdf-viewer.component.scss'],
})
export class CustomPdfViewerComponent {
  @Input() src: string;

  constructor(public modalService: NgbActiveModal) {
  }
}
