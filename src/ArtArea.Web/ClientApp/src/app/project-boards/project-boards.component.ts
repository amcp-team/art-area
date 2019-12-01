import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { ProjectService } from "../service/project.service";
import { Board } from "../model/board";

@Component({
  selector: "app-project-boards",
  templateUrl: "./project-boards.component.html",
  styleUrls: ["./project-boards.component.scss"]
})
export class ProjectBoardsComponent implements OnInit {
  Boards$: Observable<Board[]>;
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
    this.loadBoards();

    this.Boards$.subscribe(x => console.log(x));
  }

  loadBoards() {
    this.Boards$ = this.projectService.getBoards(this.projectId);
  }
}
