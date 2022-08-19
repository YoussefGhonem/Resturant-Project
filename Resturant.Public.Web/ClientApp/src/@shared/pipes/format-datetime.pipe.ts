import { Pipe } from '@angular/core';
import * as moment from 'moment';

@Pipe({
  name: 'datetime'
})
export class FormatDatetimePipe {
  transform(value: string) {
    if (!moment(new Date(value), 'd MMM y').isValid() || !value) {
      return '-'
    }
    return moment(value).format('D MMM YYYY, hh:mm A');
  }
}

// How to use it
// TODO: Use built in date pipe to allow the user to define the format he want
// <h1>{{ '15/1/2020' | formatDate}}</h1> result: 1 Jan 2020 
