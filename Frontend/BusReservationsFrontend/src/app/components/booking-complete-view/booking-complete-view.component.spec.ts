import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingCompleteViewComponent } from './booking-complete-view.component';

describe('BookingCompleteViewComponent', () => {
  let component: BookingCompleteViewComponent;
  let fixture: ComponentFixture<BookingCompleteViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingCompleteViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookingCompleteViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
