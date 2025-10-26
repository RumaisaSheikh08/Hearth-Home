import { TestBed } from '@angular/core/testing';

import { GetcataloguecategoryService } from './getcataloguecategory.service';

describe('GetcataloguecategoryService', () => {
  let service: GetcataloguecategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetcataloguecategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
