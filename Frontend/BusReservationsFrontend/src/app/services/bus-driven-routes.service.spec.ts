import { TestBed } from '@angular/core/testing';

import { BusDrivenRoutesService } from './bus-driven-routes.service';

describe('BusDrivenRoutesService', () => {
  let service: BusDrivenRoutesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BusDrivenRoutesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
