import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTowarComponent } from './add-towar.component';

describe('AddTowarComponent', () => {
  let component: AddTowarComponent;
  let fixture: ComponentFixture<AddTowarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddTowarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddTowarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
