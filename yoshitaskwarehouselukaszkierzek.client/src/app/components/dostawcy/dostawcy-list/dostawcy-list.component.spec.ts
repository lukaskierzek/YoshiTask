import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DostawcyListComponent } from './dostawcy-list.component';

describe('DostawcyListComponent', () => {
  let component: DostawcyListComponent;
  let fixture: ComponentFixture<DostawcyListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DostawcyListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DostawcyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
