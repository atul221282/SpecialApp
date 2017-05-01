import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoreAutocompleteComponent } from './core-autocomplete.component';

describe('CoreAutocompleteComponent', () => {
  let component: CoreAutocompleteComponent;
  let fixture: ComponentFixture<CoreAutocompleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoreAutocompleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoreAutocompleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
