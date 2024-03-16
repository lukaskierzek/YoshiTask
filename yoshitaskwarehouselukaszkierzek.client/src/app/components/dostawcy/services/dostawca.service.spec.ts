import { TestBed } from '@angular/core/testing';

import { DostawcaService } from './dostawca.service';

describe('DostawcaService', () => {
  let service: DostawcaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DostawcaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
