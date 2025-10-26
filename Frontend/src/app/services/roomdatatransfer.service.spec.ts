import { TestBed } from '@angular/core/testing';

import { RoomdatatransferService } from './roomdatatransfer.service';

describe('RoomdatatransferService', () => {
  let service: RoomdatatransferService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoomdatatransferService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
