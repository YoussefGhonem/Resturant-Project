import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { ngbModalOptions } from '@shared/default-values';
import { CreateUserComponent } from './create-user/create-user.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent extends BaseComponent implements OnInit {
  breadCrumbItems!: Array<{}>;
  form!: FormGroup;

  constructor(public activeModal: NgbActiveModal, private router: Router,
    public modalService: NgbModal,
    public override injector: Injector,
    private _formBuilder: FormBuilder) {
    super(injector);
  }

  ngOnInit(): void {
    this.breadCrumbItems = [
      { label: 'Home' },
      { label: 'Users', active: true }
    ];
    this.initSearchForm();
  }

  private initSearchForm(): void {
    this.form = this._formBuilder.group({
      name: new FormControl(''),
      isActive: new FormControl(''),
      isVerified: new FormControl(''),
    });
  }

  loadData() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  createUser() {
    const modalRef = this.modalService.open(CreateUserComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'md'
    });
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadData())
      .catch(() => {
      });
  }
}
