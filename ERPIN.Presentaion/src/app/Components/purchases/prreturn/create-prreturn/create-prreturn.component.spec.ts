import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePrreturnComponent } from './create-prreturn.component';

describe('CreatePrreturnComponent', () => {
  let component: CreatePrreturnComponent;
  let fixture: ComponentFixture<CreatePrreturnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatePrreturnComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePrreturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
