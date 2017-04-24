import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegitserFranchiseComponent } from './regitser-franchise.component';

describe('RegitserFranchiseComponent', () => {
  let component: RegitserFranchiseComponent;
  let fixture: ComponentFixture<RegitserFranchiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegitserFranchiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegitserFranchiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
