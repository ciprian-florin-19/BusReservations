import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddReservationViewComponent } from './add-reservation-view.component';

describe('AddReservationViewComponent', () => {
  let component: AddReservationViewComponent;
  let fixture: ComponentFixture<AddReservationViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddReservationViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddReservationViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
