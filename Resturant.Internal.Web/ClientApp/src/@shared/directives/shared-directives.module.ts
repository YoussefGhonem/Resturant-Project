import { NgModule } from '@angular/core';
import { ClickStopPropagationDirective } from "@shared/directives/click-stop-propagation.directive";
import { DefaultImageOnErrorDirective } from "@shared/directives/default-image-on-error.directive";
import { EmptyToNullDirective } from "@shared/directives/empty-to-null.directive";
import { ActiveStatusBadgeDirective } from "@shared/directives/active-status-badge.directive";

@NgModule({
  declarations: [
    ClickStopPropagationDirective,
    DefaultImageOnErrorDirective,
    EmptyToNullDirective,
    ActiveStatusBadgeDirective
  ],
  exports: [
    ClickStopPropagationDirective,
    DefaultImageOnErrorDirective,
    EmptyToNullDirective,
    ActiveStatusBadgeDirective
  ]
})
export class SharedDirectivesModule {
}
