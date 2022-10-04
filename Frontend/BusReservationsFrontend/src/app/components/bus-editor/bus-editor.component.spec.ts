import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusEditorComponent } from './bus-editor.component';

describe('BusEditorComponent', () => {
  let component: BusEditorComponent;
  let fixture: ComponentFixture<BusEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BusEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
