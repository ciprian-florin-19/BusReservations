import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BdrEditorComponent } from './bdr-editor.component';

describe('BdrEditorComponent', () => {
  let component: BdrEditorComponent;
  let fixture: ComponentFixture<BdrEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BdrEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BdrEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
