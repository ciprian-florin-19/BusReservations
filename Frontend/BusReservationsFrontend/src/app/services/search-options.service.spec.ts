import { TestBed } from '@angular/core/testing';

import { SearchOptionsService } from './search-options.service';

describe('SearchOptionsService', () => {
  let service: SearchOptionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchOptionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
