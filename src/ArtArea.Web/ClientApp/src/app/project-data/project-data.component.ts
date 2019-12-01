import { Component, OnInit } from "@angular/core";
import { Project } from "../model/project";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { ProjectService } from "../service/project.service";

@Component({
  selector: "app-project-data",
  templateUrl: "./project-data.component.html",
  styleUrls: ["./project-data.component.scss"]
})
export class ProjectDataComponent implements OnInit {
  projectData$: Observable<Project>;
  projectId: string;

  constructor(
    private projectService: ProjectService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params => {
      this.projectId =
        params["username"] +
        "." +
        (<string>params["project"]).toLowerCase().replace(" ", "-");
    });
  }

  ngOnInit() {
    this.projectData$ = this.projectService.getProjectData(this.projectId);
  }
}
