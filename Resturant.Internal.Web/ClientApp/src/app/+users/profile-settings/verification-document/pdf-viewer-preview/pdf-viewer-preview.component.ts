import { Component } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'pdf-viewer-preview',
  templateUrl: './pdf-viewer-preview.component.html',
  styleUrls: ['./pdf-viewer-preview.component.scss'],
})
export class PdfViewerComponent {
  src = 'https://vadimdez.github.io/ng2-pdf-viewer/assets/pdf-test.pdf';

  constructor(
    public modalService: NgbActiveModal
  )
  {

  }
}
