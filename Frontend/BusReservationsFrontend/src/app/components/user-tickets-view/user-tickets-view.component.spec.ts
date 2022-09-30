import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserTicketsViewComponent } from './user-tickets-view.component';

describe('UserTicketsViewComponent', () => {
  let component: UserTicketsViewComponent;
  let fixture: ComponentFixture<UserTicketsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserTicketsViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserTicketsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
