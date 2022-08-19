import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Page402Component } from './page402.component';

describe('Page402Component', () => {
  let component: Page402Component;
  let fixture: ComponentFixture<Page402Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Page402Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Page402Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
