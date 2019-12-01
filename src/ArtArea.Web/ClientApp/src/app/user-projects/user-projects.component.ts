import { Component, OnInit } from "@angular/core";
import { UserService } from "../service/user.service";
import { ActivatedRoute } from "@angular/router";
import { from, Observable } from "rxjs";
import { Project } from "../model/project";
import { UserData } from "../model/userdata";

@Component({
  selector: "app-user-projects",
  templateUrl: "./user-projects.component.html",
  styleUrls: ["./user-projects.component.scss"]
})
export class UserProjectsComponent implements OnInit {
  projects$: Observable<Project[]>;
  username: string;

  constructor(private UserService: UserService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.username = params["username"];
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
