import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDostawcyComponent } from './add-dostawcy.component';

describe('AddDostawcyComponent', () => {
  let component: AddDostawcyComponent;
  let fixture: ComponentFixture<AddDostawcyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddDostawcyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddDostawcyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
