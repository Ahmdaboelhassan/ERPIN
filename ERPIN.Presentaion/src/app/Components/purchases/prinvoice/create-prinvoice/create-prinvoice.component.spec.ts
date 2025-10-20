import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePrinvoiceComponent } from './create-prinvoice.component';

describe('CreatePrinvoiceComponent', () => {
  let component: CreatePrinvoiceComponent;
  let fixture: ComponentFixture<CreatePrinvoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatePrinvoiceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePrinvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
