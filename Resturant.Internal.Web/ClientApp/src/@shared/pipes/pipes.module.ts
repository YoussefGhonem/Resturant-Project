import { NgModule } from '@angular/core';
import { EnumToListPipe } from '@shared/pipes/enum-to-list.pipe';
import { ExtractNestedValuePipe } from '@shared/pipes/extract-nested-value.pipe';
import { FormatDatePipe } from '@shared/pipes/format-date.pipe';
import { FormatDatetimePipe } from '@shared/pipes/format-datetime.pipe';
import { FormatIntegerPipe } from '@shared/pipes/format-integer.pipe';
import { FormatPercentPipe } from '@shared/pipes/format-percent.pipe';
import { FormatPricePipe } from '@shared/pipes/format-price.pipe';
import { HumanizePipe } from '@shared/pipes/humanize.pipe';
import { FormatDecimalPipe } from "@shared/pipes/format-decimal.pipe";
import { FormatTimePipe } from '@shared/pipes/format-time.pipe';
import { SecureFilePipe } from "@shared/pipes/secure-file.pipe";
import { ShortNumberPipe } from "@shared/pipes/short-number.pipe";
import { TruncatePipe } from './truncate-description.pipe';

@NgModule({
  declarations: [
    FormatDatePipe,
    FormatDatetimePipe,
    FormatIntegerPipe,
    FormatDecimalPipe,
    FormatPercentPipe,
    FormatPricePipe,
    ExtractNestedValuePipe,
    HumanizePipe,
    EnumToListPipe,
    FormatTimePipe,
    SecureFilePipe,
    ShortNumberPipe,
    TruncatePipe
  ],
  exports: [
    FormatDatePipe,
    FormatTimePipe,
    FormatDatetimePipe,
    FormatIntegerPipe,
    FormatPercentPipe,
    FormatPricePipe,
    ExtractNestedValuePipe,
    HumanizePipe,
    EnumToListPipe,
    FormatDecimalPipe,
    SecureFilePipe,
    ShortNumberPipe,
    TruncatePipe
  ]
})
export class SharedPipesModule {
}
