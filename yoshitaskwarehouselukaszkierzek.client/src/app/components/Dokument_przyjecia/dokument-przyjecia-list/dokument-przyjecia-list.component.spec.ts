import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DokumentPrzyjeciaListComponent } from './dokument-przyjecia-list.component';

describe('DokumentPrzyjeciaListComponent', () => {
  let component: DokumentPrzyjeciaListComponent;
  let fixture: ComponentFixture<DokumentPrzyjeciaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DokumentPrzyjeciaListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DokumentPrzyjeciaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
