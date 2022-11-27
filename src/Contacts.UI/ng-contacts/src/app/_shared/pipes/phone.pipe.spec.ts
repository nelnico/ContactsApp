import { PhonePipe } from './phone.pipe';

describe('PhonePipe', () => {
  it('create an instance of pipe class', () => {
    const pipe = new PhonePipe();
    expect(pipe).toBeTruthy();
  });
  it('format a phone number correctly', () => {
    const pipe = new PhonePipe();
    let number = '0826899430';
    let result = pipe.transform(number);
    expect(result).toEqual('(082) 689 9430');
  })
});
