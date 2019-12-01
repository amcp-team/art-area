import { Component, OnInit } from "@angular/core";
import { AuthenticationService } from "../app-auth/authentication.service";

@Component({
  selector: "app-nav-user-badge",
  templateUrl: "./nav-user-badge.component.html",
  styleUrls: ["./nav-user-badge.component.scss"]
})
export class NavUserBadgeComponent implements OnInit {
  isLoggedIn: boolean = false;
  username = "";
  constructor(private authService: AuthenticationService) {}

  ngOnInit() {
    if (this.authService.currentUserValue != null) {
      // console.log(this.authService.currentUserValue);
      // console.log(this.authService.currentUserValue == null);
      // console.log(this.authService.currentUserValue === null);
      this.isLoggedIn = true;
      this.username = this.authService.currentUserValue.username;
    }
  }
}
