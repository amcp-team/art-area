import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsernameBadgeComponent } from './username-badge.component';

describe('UsernameBadgeComponent', () => {
  let component: UsernameBadgeComponent;
  let fixture: ComponentFixture<UsernameBadgeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsernameBadgeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsernameBadgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
