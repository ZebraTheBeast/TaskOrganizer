import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'statusPipe' })
export class StatusPipe implements PipeTransform {
  transform(value: number): string {
    if (value == 0) {
      return "New";
    }
    if (value == 1) {
      return "In progress";
    }
    if (value == 2) {
      return "Done";
    }
  }
}
