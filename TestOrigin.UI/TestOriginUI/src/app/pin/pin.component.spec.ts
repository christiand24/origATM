import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PINComponent } from './pin.component';

describe('PINComponent', () => {
  let component: PINComponent;
  let fixture: ComponentFixture<PINComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PINComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PINComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
