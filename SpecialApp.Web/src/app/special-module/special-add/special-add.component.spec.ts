import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialAddComponent } from './special-add.component';

describe('SpecialAddComponent', () => {
  let component: SpecialAddComponent;
  let fixture: ComponentFixture<SpecialAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecialAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
