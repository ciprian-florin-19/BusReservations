import { TestBed } from '@angular/core/testing';

import { DrivenRouteService } from './driven-route.service';

describe('DrivenRouteService', () => {
  let service: DrivenRouteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DrivenRouteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
