import { TestBed } from '@angular/core/testing';

import { DatatableServerService } from './datatable-server.service';

describe('DatatableServerService', () => {
  let service: DatatableServerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatatableServerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
