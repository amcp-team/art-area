import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserPageModel } from '../models/userpage';
import { from, Observable } from 'rxjs';
import { UserPageServiceService } from '../services/user-page-service.service';

@Component({
  selector: 'app-user-plate',
  templateUrl: './user-plate.component.html',
  styleUrls: ['./user-plate.component.css']
})
export class UserPlateComponent implements OnInit {
  userPage$: Observable<UserPageModel>;
  UId: number;

  userInfo={
    name: "Sergey",
    description: "description"
  }

  constructor(private userPageService: UserPageServiceService, private avRoute: ActivatedRoute) { 
    const idParam = 'id';
    if(this.avRoute.snapshot.params[idParam]){
      this.UId = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadUserInfo();
  }

  loadUserInfo(){
    this.userPage$ = this.userPageService.getUserInfo(this.UId);
  }

}
