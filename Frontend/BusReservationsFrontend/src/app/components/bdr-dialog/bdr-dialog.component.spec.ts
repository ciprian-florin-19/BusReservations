import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BdrDialogComponent } from './bdr-dialog.component';

describe('BdrDialogComponent', () => {
  let component: BdrDialogComponent;
  let fixture: ComponentFixture<BdrDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BdrDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BdrDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
