import { Component, OnInit } from "@angular/core";
import { UserService } from "../service/user.service";
import { ActivatedRoute } from "@angular/router";
import { from, Observable } from "rxjs";
import { Project } from "../model/project";
import { UserData } from "../model/userdata";
import { AuthenticationService } from "../app-auth/authentication.service";

@Component({
  selector: "app-user-projects",
  templateUrl: "./user-projects.component.html",
  styleUrls: ["./user-projects.component.scss"]
})
export class UserProjectsComponent implements OnInit {
  projects$: Observable<Project[]>;
  username: string;
  canCreate: boolean = false;

  constructor(
    private UserService: UserService,
    private route: ActivatedRoute,
    private authService: AuthenticationService
  ) {
    this.route.params.subscribe(params => {
      this.username = params["username"];

      if (
        authService.currentUserValue &&
        authService.currentUserValue.username == this.username
      ) {
        this.canCreate = true;
      }
    });
  }

  ngOnInit() {
    this.loadProjects();

    this.projects$.subscribe(x => console.log(x));
  }

  loadProjects() {
    this.projects$ = this.UserService.getProjects(this.username);
  }
}
