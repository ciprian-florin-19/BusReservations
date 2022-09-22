import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusSchemaComponent } from './bus-schema.component';

describe('BusSchemaComponent', () => {
  let component: BusSchemaComponent;
  let fixture: ComponentFixture<BusSchemaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusSchemaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BusSchemaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
