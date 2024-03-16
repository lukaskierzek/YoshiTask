import { TestBed } from '@angular/core/testing';

import { DokumentPrzyjeciaService } from './dokument-przyjecia.service';

describe('DokumentPrzyjeciaService', () => {
  let service: DokumentPrzyjeciaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DokumentPrzyjeciaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
