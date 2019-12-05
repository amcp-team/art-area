import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { ProjectService } from "../service/project.service";


@Component({
  selector: 'app-project-create-board',
  templateUrl: './project-create-board.component.html',
  styleUrls: ['./project-create-board.component.scss']
})
export class ProjectCreateBoardComponent implements OnInit {
  createBoardForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private projectService: ProjectService,
  ) { }

  ngOnInit() {
    this.createBoardForm = this.formBuilder.group({
      title: ["", Validators.required],
      description: ["", Validators.required]
    })
  }

  get form() {
    return this.createBoardForm.controls;
  }

  onSubmit() {
    this.projectService
      .postBoard(this.form.title.value, this.form.description.value)
      .pipe(first())
      
  }

}
