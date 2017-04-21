import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoreUserMenuComponent } from './core-user-menu.component';

describe('CoreUserMenuComponent', () => {
  let component: CoreUserMenuComponent;
  let fixture: ComponentFixture<CoreUserMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoreUserMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoreUserMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
