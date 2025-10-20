import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PRReturnComponent } from './prreturn.component';

describe('PRReturnComponent', () => {
  let component: PRReturnComponent;
  let fixture: ComponentFixture<PRReturnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PRReturnComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PRReturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
