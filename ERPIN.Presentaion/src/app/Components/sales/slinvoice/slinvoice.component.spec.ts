import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SLInvoiceComponent } from './slinvoice.component';

describe('SLInvoiceComponent', () => {
  let component: SLInvoiceComponent;
  let fixture: ComponentFixture<SLInvoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SLInvoiceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SLInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
