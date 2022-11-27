import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone',
})
export class PhonePipe implements PipeTransform {
  transform(value: string): string {
    let part1 = value.substring(0, 3);
    let part2 = value.substring(3, 6);
    let part3 = value.substring(6, value.length);

    return `(${part1}) ${part2} ${part3}`;
  }
}
