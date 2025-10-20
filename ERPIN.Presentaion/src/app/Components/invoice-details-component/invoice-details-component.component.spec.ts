import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceDetailsComponentComponent } from './invoice-details-component.component';

describe('InvoiceDetailsComponentComponent', () => {
  let component: InvoiceDetailsComponentComponent;
  let fixture: ComponentFixture<InvoiceDetailsComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InvoiceDetailsComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvoiceDetailsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
