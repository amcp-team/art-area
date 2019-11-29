import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCreateProjectComponent } from './user-create-project.component';

describe('UserCreateProjectComponent', () => {
  let component: UserCreateProjectComponent;
  let fixture: ComponentFixture<UserCreateProjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserCreateProjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserCreateProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
