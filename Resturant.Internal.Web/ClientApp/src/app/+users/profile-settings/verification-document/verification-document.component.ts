import { takeUntil } from 'rxjs/operators';
import { PdfViewerComponent } from './pdf-viewer-preview/pdf-viewer-preview.component';
import { AddSignatureComponent } from './../signature-pad-popup/signature-pad-popup.component';
import { BaseComponent } from '@shared/base/base.component';
import { AfterViewChecked, ChangeDetectorRef, Component, Injector, OnInit } from "@angular/core";
import { ngbModalOptions } from '@shared/default-values';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { saveAs } from 'file-saver';
import { SettingsController } from 'app/+users/controllers';


@Component({
  selector: 'verification-document',
  templateUrl: './verification-document.component.html',
  styleUrls: ['./verification-document.component.scss']
})

export class VerificationTabComponent extends BaseComponent implements OnInit, AfterViewChecked {
  signatureImage: any;

  constructor(
      public override injector: Injector,
      public activeModal: NgbActiveModal,
      private modalService: NgbModal,
      private _ref: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    // this.httpService.GET('', undefined, false)
    // .subscribe((image) => {
    //   this.signatureImage = image;
    // });
  }

  addSignature() {
    const modalRef = this.modalService.open(AddSignatureComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'lg'
    });
    modalRef.componentInstance.onSaveSend.subscribe(event => {
      this.signatureImage = event;
      this.httpService.PUT('', this.signatureImage, undefined, false)
      .subscribe(() => {
        this.notificationService.success("Success", "Bingo");
      });
    })
    modalRef
        .result
        .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true))
        .catch(() => {
        });
  }

  showPdf() {
    const modalRef = this.modalService.open(PdfViewerComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'xl'
    });
    modalRef
        .result
        .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true))
        .catch(() => {
        });
  }

  downloadPdf() {
    this.httpService.GET(SettingsController.getVerificationDocument, undefined, false)
    .pipe(takeUntil(this.ngUnsubscribe))
    .toPromise()
    .then((data: any) => {
      saveAs(data.verificationDocument, 'VerificationDocument.pdf');
    });
  }

  ngAfterViewChecked(): void {
  }
}
