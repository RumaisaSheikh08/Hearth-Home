import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckoutformComponent } from './checkoutform.component';

describe('CheckoutformComponent', () => {
  let component: CheckoutformComponent;
  let fixture: ComponentFixture<CheckoutformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CheckoutformComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CheckoutformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
