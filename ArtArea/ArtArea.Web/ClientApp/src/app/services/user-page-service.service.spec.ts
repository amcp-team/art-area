import { TestBed } from '@angular/core/testing';

import { UserPageServiceService } from './user-page-service.service';

describe('UserPageServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserPageServiceService = TestBed.get(UserPageServiceService);
    expect(service).toBeTruthy();
  });
});
