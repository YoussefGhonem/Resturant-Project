import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { SharedDirectivesModule } from "@shared/directives/shared-directives.module";
import { SharedPipesModule } from "@shared/pipes/pipes.module";
import { ReactiveFormsModule } from "@angular/forms";
import { ReactiveValidationModule } from "angular-reactive-validation";
import { NgxMaskModule } from "ngx-mask";
import { NgbTooltipModule } from "@ng-bootstrap/ng-bootstrap";
import { PaginationModule } from './pagination/pagination.module';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    SharedDirectivesModule,
    SharedPipesModule,
    ReactiveFormsModule,
    ReactiveValidationModule,
    NgxMaskModule.forRoot(),
    NgbTooltipModule,
    PaginationModule
  ],
  exports: [
    PaginationModule
  ]
})
export class SharedComponentsModule {
}
