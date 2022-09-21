import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusDrivenRoutesViewComponent } from './bus-driven-routes-view.component';

describe('BusDrivenRoutesViewComponent', () => {
  let component: BusDrivenRoutesViewComponent;
  let fixture: ComponentFixture<BusDrivenRoutesViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusDrivenRoutesViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BusDrivenRoutesViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
