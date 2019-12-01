import { Component, OnInit } from "@angular/core";
import { UserService } from "../service/user.service";
import { UserData } from "../model/userdata";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";

@Component({
  selector: "app-user-data",
  templateUrl: "./user-data.component.html",
  styleUrls: ["./user-data.component.scss"]
})
export class UserDataComponent implements OnInit {
  userData$: Observable<UserData>;
  username: string;

  constructor(private userService: UserService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.username = params["username"];
    });
  }

  ngOnInit() {
    this.userData$ = this.userService.getUserData(this.username);
  }
}
