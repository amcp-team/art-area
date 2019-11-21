import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPlateComponent } from './user-plate.component';

describe('UserPlateComponent', () => {
  let component: UserPlateComponent;
  let fixture: ComponentFixture<UserPlateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserPlateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPlateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
