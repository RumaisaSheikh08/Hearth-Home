import { TestBed } from '@angular/core/testing';

import { GetcatalogueService } from './getcatalogue.service';

describe('GetcatalogueService', () => {
  let service: GetcatalogueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetcatalogueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
