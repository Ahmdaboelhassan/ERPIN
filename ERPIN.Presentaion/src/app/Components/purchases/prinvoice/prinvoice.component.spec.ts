import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PRInvoiceComponent } from './prinvoice.component';

describe('PRInvoiceComponent', () => {
  let component: PRInvoiceComponent;
  let fixture: ComponentFixture<PRInvoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PRInvoiceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PRInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
