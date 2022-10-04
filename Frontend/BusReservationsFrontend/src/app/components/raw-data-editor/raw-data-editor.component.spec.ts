import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RawDataEditorComponent } from './raw-data-editor.component';

describe('RawDataEditorComponent', () => {
  let component: RawDataEditorComponent;
  let fixture: ComponentFixture<RawDataEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RawDataEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RawDataEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
