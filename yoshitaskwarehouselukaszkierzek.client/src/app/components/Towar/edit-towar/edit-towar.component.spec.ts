import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTowarComponent } from './edit-towar.component';

describe('EditTowarComponent', () => {
  let component: EditTowarComponent;
  let fixture: ComponentFixture<EditTowarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditTowarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditTowarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
