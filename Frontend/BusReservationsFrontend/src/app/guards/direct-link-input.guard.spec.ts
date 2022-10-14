import { TestBed } from '@angular/core/testing';

import { DirectLinkInputGuard } from './direct-link-input.guard';

describe('DirectLinkInputGuard', () => {
  let guard: DirectLinkInputGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(DirectLinkInputGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
