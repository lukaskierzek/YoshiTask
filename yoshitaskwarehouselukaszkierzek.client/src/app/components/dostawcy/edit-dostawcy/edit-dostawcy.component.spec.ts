import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDostawcyComponent } from './edit-dostawcy.component';

describe('EditDostawcyComponent', () => {
  let component: EditDostawcyComponent;
  let fixture: ComponentFixture<EditDostawcyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditDostawcyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditDostawcyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
