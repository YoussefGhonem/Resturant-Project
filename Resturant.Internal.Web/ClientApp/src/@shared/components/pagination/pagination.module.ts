import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from '@shared/components/pagination/pagination.component';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedDirectivesModule } from "@shared/directives/shared-directives.module";
import { SharedPipesModule } from "@shared/pipes/pipes.module";
import { ReactiveFormsModule } from "@angular/forms";
import { ReactiveValidationModule } from "angular-reactive-validation";
import { NgxMaskModule } from "ngx-mask";
import { NgbTooltipModule } from "@ng-bootstrap/ng-bootstrap";

@NgModule({
  declarations: [
    PaginationComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    CommonModule,
    SharedDirectivesModule,
    SharedPipesModule,
    ReactiveFormsModule,
    ReactiveValidationModule,
    NgxMaskModule.forRoot(),
    NgbTooltipModule,
  ],
  exports: [PaginationComponent]
})
export class PaginationModule {
}
