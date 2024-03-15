import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TowarListComponent } from './towar-list.component';

describe('TowarListComponent', () => {
  let component: TowarListComponent;
  let fixture: ComponentFixture<TowarListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TowarListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TowarListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
