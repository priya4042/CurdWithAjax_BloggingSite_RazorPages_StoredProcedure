import { TestBed } from '@angular/core/testing';

import { CanactivategaurdServiceService } from './canactivategaurd-service.service';

describe('CanactivategaurdServiceService', () => {
  let service: CanactivategaurdServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CanactivategaurdServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
