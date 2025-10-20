import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSlreturnComponent } from './create-slreturn.component';

describe('CreateSlreturnComponent', () => {
  let component: CreateSlreturnComponent;
  let fixture: ComponentFixture<CreateSlreturnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateSlreturnComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateSlreturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
