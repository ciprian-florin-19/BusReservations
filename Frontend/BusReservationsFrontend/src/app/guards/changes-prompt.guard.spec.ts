import { TestBed } from '@angular/core/testing';

import { ChangesPromptGuard } from './changes-prompt.guard';

describe('ChangesPromptGuard', () => {
  let guard: ChangesPromptGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ChangesPromptGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
