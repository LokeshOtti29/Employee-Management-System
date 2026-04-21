import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Sideview } from './sideview';

describe('Sideview', () => {
  let component: Sideview;
  let fixture: ComponentFixture<Sideview>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Sideview]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Sideview);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
