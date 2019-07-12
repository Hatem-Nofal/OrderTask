/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { Errorinterceptor } from './error.interceptor';

describe('Service: Error.interceptor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Errorinterceptor]
    });
  });

  it('should ...', inject([Errorinterceptor], (service: Errorinterceptor) => {
    expect(service).toBeTruthy();
  }));
});
