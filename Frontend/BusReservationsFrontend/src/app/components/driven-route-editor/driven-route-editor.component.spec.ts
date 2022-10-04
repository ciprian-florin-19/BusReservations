import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrivenRouteEditorComponent } from './driven-route-editor.component';

describe('DrivenRouteEditorComponent', () => {
  let component: DrivenRouteEditorComponent;
  let fixture: ComponentFixture<DrivenRouteEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrivenRouteEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DrivenRouteEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
