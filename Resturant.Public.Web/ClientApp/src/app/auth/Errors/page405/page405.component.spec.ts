import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Page405Component } from './page405.component';

describe('Page405Component', () => {
  let component: Page405Component;
  let fixture: ComponentFixture<Page405Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Page405Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Page405Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
