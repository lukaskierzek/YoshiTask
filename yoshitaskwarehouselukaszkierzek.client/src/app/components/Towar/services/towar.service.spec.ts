import { TestBed } from '@angular/core/testing';

import { TowarService } from './towar.service';

describe('TowarService', () => {
  let service: TowarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TowarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
