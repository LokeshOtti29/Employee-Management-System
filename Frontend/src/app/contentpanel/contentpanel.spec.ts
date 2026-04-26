import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Contentpanel } from './contentpanel';

describe('Contentpanel', () => {
  let component: Contentpanel;
  let fixture: ComponentFixture<Contentpanel>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Contentpanel]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Contentpanel);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
