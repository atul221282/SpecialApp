import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterFranchiseComponent } from './register-franchise.component';

describe('RegisterFranchiseComponent', () => {
  let component: RegisterFranchiseComponent;
  let fixture: ComponentFixture<RegisterFranchiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterFranchiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterFranchiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
