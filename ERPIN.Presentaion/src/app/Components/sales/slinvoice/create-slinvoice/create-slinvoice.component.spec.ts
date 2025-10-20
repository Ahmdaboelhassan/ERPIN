import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSlinvoiceComponent } from './create-slinvoice.component';

describe('CreateSlinvoiceComponent', () => {
  let component: CreateSlinvoiceComponent;
  let fixture: ComponentFixture<CreateSlinvoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateSlinvoiceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateSlinvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
