import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { ProjectService } from "../service/project.service";
import { NewBoard } from "../model/newBoard";

@Component({
  selector: "app-project-create-board",
  templateUrl: "./project-create-board.component.html",
  styleUrls: ["./project-create-board.component.scss"]
})
export class ProjectCreateBoardComponent implements OnInit {
  createBoardForm: FormGroup;
  projectId: string;
  constructor(
    private projectService: ProjectService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params => {
      this.projectId = params["username"] + "." + params["project"];
    });
  }

  ngOnInit() {
    this.createBoardForm = this.formBuilder.group({
      title: ["", Validators.required],
      description: ["", Validators.required],
      privacy: ["0"]
    });
  }

  get form() {
    return this.createBoardForm.controls;
  }

  onSubmit() {
    console.log();
    this.projectService
      .postBoard(
        this.form.title.value,
        this.form.description.value,
        this.form.privacy.value,
        this.projectId
      )
      .pipe(first())
      .subscribe(x => console.log(x));
  }
}
