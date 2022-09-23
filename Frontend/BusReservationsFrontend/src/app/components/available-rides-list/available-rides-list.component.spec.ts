import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableRidesListComponent } from './available-rides-list.component';

describe('AvailableRidesListComponent', () => {
  let component: AvailableRidesListComponent;
  let fixture: ComponentFixture<AvailableRidesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvailableRidesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvailableRidesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
