import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SLReturnComponent } from './slreturn.component';

describe('SLReturnComponent', () => {
  let component: SLReturnComponent;
  let fixture: ComponentFixture<SLReturnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SLReturnComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SLReturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
